using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPractice
{
    public class MutexDemo : IThreadTest, IDisposable
    {
        private bool _disposed = false;
        private readonly Mutex _mut = new Mutex(false, "test");
        private int _count = 0;

        public void Dispose() => Dispose(true);
        
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _mut.Dispose();
            }

            _disposed = true;
        }

        public void DoSomething()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(Thread1);
                thread.Name = $"Thread{i + 1}";
                thread.Start();
            }
        }

        private void Thread1()
        {
            var name = Thread.CurrentThread.Name;
            Console.WriteLine($"Thread {name} start");
            if (_mut.WaitOne(1000))
            {
                Console.WriteLine($"Thread {name} has entered the protected area");
                _count++;
                Console.WriteLine($"{_count}");
                Thread.Sleep(50);
                _mut.ReleaseMutex();
                Console.WriteLine($"Thread {name} has released mutex");
            }
            else
            {
                Console.WriteLine($"Thread {name} could not get mutex");
            }

            Console.WriteLine($"Thread {name} finish");
        }
    }
}
