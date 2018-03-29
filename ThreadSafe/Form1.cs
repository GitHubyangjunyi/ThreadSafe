using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ThreadSafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Thread thread = null;
        delegate void SetTextDelegate(string text);
        //此delegate通过异步操作方式设置控件的Text属性

        private void Form1_Load(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(Counter));
            thread.Start();
        }
        
        private void Counter()
        {
            while (true)
            {
                int i;
                for (i = 0; i < 1000; i++)
                {
                    this.SetText(i.ToString());//调用任务线程
                }
                Thread.Sleep(3000);
            }
        }

        private void SetText(string text)
        {
            //InvokeRequired比较线程ID以及创建控件的线程ID,如果不同返回true
            if (this.CountertBox1.InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.CountertBox1.Text = text;
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //通过调用创建控件的线程来更改控件属性,所以线程是安全的
            this.CountertBox2.Text = "计数线程终止";
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            thread.Abort();
            this.BackgroundWorker1.RunWorkerAsync();
            //调用RunWorkerAsync()方法启动BackgroundWorker1
            //控件CountertBox2的Text属性设置将在BackgroundWorker1发生RunWorkerCompleted事件之后完成
            Stop.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//关闭窗体时终止所有线程,否则程序还将处于调试状态
        {
            if (thread!= null)
            {
                thread.Abort();
            }
        }
    }
}
//C#中对于Windows窗体控件的跨线程访问,可以采取下列两种方法
//一.利用封送处理进行的线程安全调用
//鉴于控件总是由主执行线程所有,所以从属线程中对控件的任何调用都需要封送处理调用
//而封送处理是跨线程边界移动调用行为,需要消耗大量的系统资源
//因此为了使需要进行的封送处理量减到最小,并确保以线程安全方式处理调用
//应使用Control.BeginInvoke或者Control.Invoke方法来调用主执行线程上的方法
//并且在该方法调用之前,先查询相应控件的InvokeRequired属性来判断是否正在从创建这个控件的线程访问该控件
//进而采取相应的措施
//1.查询控件的InvokeRequired属性
//2.如果InvokeRequired属性返回true,则使用实际调用控件的委托来调用Invoke
//3.如果InvokeRequired属性返回false,则直接调用控件
//二.使用BackgroundWorker进行的线程安全调用
//在应用程序中实现多线程的首选方式是使用BackgroundWorker组件
//BackgroundWorker组件使用事件驱动模型实现多线程
//辅助线程运行DoWork事件处理程序,创建控件的线程运行ProgressChanged和RunWorkerCompleted事件处理程序