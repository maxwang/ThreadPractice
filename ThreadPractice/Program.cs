using System;
using System.Threading;

namespace ThreadPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            //var task1 = new MonitorTryEnter();
            //task1.DoSomething();

            //IThreadTest task = new ThreadJoin();
            //IThreadTest task = new InterlockedDemo();
            //IThreadTest task = new InterlockedDemo();
            IThreadTest task = new MutexDemo();

            task.DoSomething();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.WriteLine($"Main Thread {i}");

            }
            
            Console.ReadLine();
        }
    }
}
