using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPractice
{
    public class ThreadJoin
    {
        //Blocks the calling thread until the thread represented by this instance terminates.
        //Join(Int32)	
        //Blocks the calling thread until the thread represented by this instance terminates or the specified time elapses, while continuing to perform standard COM and SendMessage pumping.
        
        public void DoSomething()
        {
            var thread1 = new Thread(StartThread1);
            var thread2 = new Thread(StartThread2);

            thread1.Start();
            thread2.Start();

            //thread1.Join();
            //thread2.Join();
        }


        private void StartThread2()
        {
            Console.WriteLine("Thread 2 Start");
            Thread.Sleep(2000);
            Console.WriteLine("Thread 2 Finished");
        }

        private void StartThread1()
        {
            Console.WriteLine("Thread 1 Start");
            Thread.Sleep(3000);
            Console.WriteLine("Thread 1 Finished");
        }
    }
}
