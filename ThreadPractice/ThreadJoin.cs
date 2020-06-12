using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPractice
{
    public class ThreadJoin: IThreadTest
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

            //if no join, system will return to main thread,
            //if there is join, system will not return to main thread but wait for thread finish
            // such as thread 1 join, system will wait for thread finish
            //thread2.Join();
            Console.WriteLine(thread2.Join(1000)
                ? $"Thread 1 completed in 1 sec"
                : $"Thread 1 has not completed in 1 sec");

            //thread1.Join(); // if we put join here, we could only see thread 1 completed message
            for (int i = 1; i <= 10; i++)
            {
                if (thread1.IsAlive)
                {
                    Console.WriteLine("Thread 1 is still doing it's work");
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("Thread 1 Completed");
                    break;
                }
            }
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
