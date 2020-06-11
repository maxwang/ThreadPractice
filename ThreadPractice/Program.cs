using System;

namespace ThreadPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var task1 = new MonitorTryEnter();
            task1.DoSomething();

            Console.ReadLine();
        }
    }
}
