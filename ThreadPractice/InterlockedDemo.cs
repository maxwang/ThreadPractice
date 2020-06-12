using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPractice
{
    public class InterlockedDemo : IThreadTest
    {
        //Interlocked Provides atomic operations for variables that are shared by multiple threads.
        private static int _counter = 0;
        public void DoSomething()
        {
            var thread1 = new Thread(Thread1);
            var thread2 = new Thread(Thread2);
            thread1.Start();
            thread2.Start();
            //
            //thread1.Join();
            //thread2.Join();
        }

        private void Thread1()
        {
            for (int i = 0; i < 5; i++)
            {
                Interlocked.Increment(ref _counter); //_counter++ does not work here
                Console.WriteLine("Thread 1 Counter++ {0}", _counter);
                Thread.Sleep(100);
            }
        }

        private void Thread2()
        {
            for (int i = 0; i < 5; i++)
            {
                Interlocked.Increment(ref _counter);
                Console.WriteLine("Thread 2 Counter++ {0}", _counter);
                Thread.Sleep(100);
            }
        }
    }
}
