using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public delegate void StartTheThread();
        public EventHandler

        static void Main(string[] args)
        {
            Console.WriteLine("Start a second thread.");

            Thread t = new Thread(new ThreadStart(ThreadProc));

            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread do some work");
                Thread.Sleep(1000);
            }
            Console.ReadLine();
        }

        private static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                // Yield the rest of the time slice.
                Thread.Sleep(0);
            }
        }
    }
}
