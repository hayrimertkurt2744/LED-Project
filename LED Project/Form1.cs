using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LED_Project
{
    public partial class Form1 : Form
    {
        public delegate void CallBackColor(int code, string msg);
        event CallBackColor CallBackColorEventHandler;
        ThreadStart childRef;
        Thread childThread;
        ThreadStart child2Ref;
        Thread child2Thread;


        Color currentColor = Color.Black;
        public Form1()
        {

            InitializeComponent();
        }

        private async void StartTask()
        {
            labelResult.Text = "waiting for task to complete";
            //await task.run(() => colorchanger());
            
        }
        
        private void ColorChanger(/*color color1*/)
        {
            pictureBox1.BeginInvoke((MethodInvoker)delegate () {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("timer #1 :" + i + " seconds");
                    pictureBox1.BackColor = SwapColor(pictureBox1.BackColor);//use delegate here
                    //CallBackColorEventHandler.Invoke(1, "Blink 1");
                    Console.WriteLine(pictureBox1.BackColor);
                    Thread.Sleep(1000);

                }
            });
        }

        private void ColorChanger2(/*color color1*/)
        {
            if (pictureBox2.InvokeRequired)
            {
                pictureBox2.BeginInvoke((MethodInvoker)delegate () {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("timer #1 :" + i + " seconds");
                        pictureBox2.BackColor = SwapColor(pictureBox2.BackColor);//use delegate here
                        //CallBackColorEventHandler.Invoke(2, "Blink2");
                        Console.WriteLine(pictureBox1.BackColor);
                        Thread.Sleep(1000);

                    }
                });
            }
        }
        public void MyCallbackColor(int code,string msg) 
        {
            switch (code)
            {
                case 0:
                    break;
                case 1:
                    if (pictureBox1.InvokeRequired)
                    {
                        pictureBox1.BeginInvoke((MethodInvoker)delegate () {
                            this.pictureBox1.BackColor = SwapColor(pictureBox1.BackColor);
                        });
                        Console.WriteLine(msg);
                    }
                    else
                    {
                        pictureBox1.BackColor = SwapColor(pictureBox1.BackColor);
                        Console.WriteLine(msg);
                    }
                    break;
                case 2:
                    if (pictureBox2.InvokeRequired)
                    {
                        pictureBox2.BeginInvoke((MethodInvoker)delegate () {
                            this.pictureBox2.BackColor = SwapColor(pictureBox2.BackColor);
                        });
                        Console.WriteLine(msg);
                    }
                    else
                    {
                        pictureBox2.BackColor = SwapColor(pictureBox2.BackColor);
                        Console.WriteLine(msg);
                    }
                    break;
                default:
                    break;
            }
        }


        private Color SwapColor(Color color1)
        {
            Color localcolor = color1;

            if (localcolor == Color.Black)
            {
                localcolor = Color.Yellow;

            }
            else if (localcolor == Color.Yellow)
            {
                localcolor = Color.Black;

            }
            return localcolor;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t = Thread.CurrentThread;
            t.Name = "Main Thread";
            //CallBackColorEventHandler += MyCallbackColor;

            ThreadStart childRef = new ThreadStart(ColorChanger);
            //Console.WriteLine("In Main:Creating the Child thread");
            Thread childThread = new Thread(childRef);

            ThreadStart child2Ref = new ThreadStart(ColorChanger2);
            Thread child2Thread = new Thread(child2Ref);
            childThread.Start();
            child2Thread.Start();
            Console.WriteLine(Thread.CurrentThread.Name);
            Console.ReadLine();


            //onColorChange += ColorChanger;
            //onColorChange += ColorChanger1;
        }

        private void CallToChildRead()
        {
            Thread t = Thread.CurrentThread;
            t.Name = "child thread";
            Thread.Sleep(1000);
            Console.WriteLine("Child thread starts.");
            Console.WriteLine(t.Name);
        }
        private void CallToChild2Read()
        {
            Thread t = Thread.CurrentThread;
            t.Name = "child thread";
            Thread.Sleep(1000);
            Console.WriteLine("Child thread starts.");
            Console.WriteLine(t.Name);
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            
        }

        //private async task blinktheled1()
        //{
        //    await task.run(() => 
        //    {
        //        for (int i = 0; i < 10; i++)
        //        {
        //            console.writeline("timer #1 :" + i + " seconds");
        //            picturebox1.backcolor = swapcolor(picturebox1.backcolor);
        //            console.writeline(picturebox1.backcolor);
        //            thread.sleep(1000);
        //        }

        //    });
        //    console.writeline("color change completed");
        //}
        //private async task blinktheled2()
        //{
        //    await task.run(() =>
        //    {
        //        for (int i = 0; i < 10; i++)
        //        {
        //            console.writeline("timer #1 :" + i + " seconds");
        //            picturebox2.backcolor = swapcolor1(picturebox1.backcolor);
        //            console.writeline(picturebox2.backcolor);
        //            thread.sleep(1000);
        //        }

        //    });
        //    console.writeline("color change completed");
        //}
    }
}
