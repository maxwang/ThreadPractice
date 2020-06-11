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

            var task2 = new ThreadJoin();
            task2.DoSomething();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"Main Thread {i}");

            }

            Console.ReadLine();
        }
    }
}
