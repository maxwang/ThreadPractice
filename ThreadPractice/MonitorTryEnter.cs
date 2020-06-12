using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPractice
{
    public class MonitorTryEnter : IThreadTest
    {
        private static readonly object _lockObj = new Object();
        // we should use monitor tryenter to avoid dead lock
        // lock is a short version for monitor tryenter/monitor exit
        // lock might cause dead lock, lock use Monitor.Enter which does  not accept timeout parameter
        public void DoSomething()
        {
            
            var timeout = TimeSpan.FromMilliseconds(500);
            bool lockTaken = false;

            try
            {
                Monitor.TryEnter(_lockObj, timeout, ref lockTaken);
                if (lockTaken)
                {
                    // The critical section.
                    Console.WriteLine("Do something inside MonitorTryEnter");
                }
                else
                {
                    // The lock was not acquired.
                    Console.WriteLine("Could not enter, dead lock might happen");
                }
            }
            finally
            {
                // Ensure that the lock is released.
                if (lockTaken)
                {
                    Monitor.Exit(_lockObj);
                }
            }
        }
    }
}
