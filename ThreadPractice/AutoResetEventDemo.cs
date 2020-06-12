using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPractice
{
    public class AutoResetEventDemo : IThreadTest
    {
        //this is a quick demo for auto reset event,
        //new thread will stop and wait for signal to continue, you could add a timeout
        //Represents a thread synchronization event that, when signaled, resets automatically after releasing a single waiting thread. This class cannot be inherited.
        private readonly AutoResetEvent _paidEvent = new AutoResetEvent(false);
        private readonly AutoResetEvent _pickEvent = new AutoResetEvent(false);
        public void DoSomething()
        {
            

            for (int i = 0; i < 10; i++)
            {
                var payThread = new Thread(PayThread) {Name = "payment thread"};
                var pickupThread = new Thread(PickupThread) {Name = "Pickup thread"};
                payThread.Start();
                pickupThread.Start();

                Console.WriteLine("Wait for payment authorize");
                Console.ReadLine();
                _paidEvent.Set();
                Console.WriteLine("Wait for pickup authorize");
                Console.ReadLine();
                _pickEvent.Set();
            }

        }

        private void PickupThread()
        {
            string name = Thread.CurrentThread.Name;
            Console.WriteLine($"{name}, wait for Authorize");
            _pickEvent.WaitOne();
            //if (_pickEvent.WaitOne(1000))
            //{
            //    Console.WriteLine($"{name} is released");
            //}
            //else
            //{
            //    Console.WriteLine($"{name} is not released in 1 sec");
            //}
            Console.WriteLine($"{name} is released");
            Console.WriteLine($"{name} ends.");
        }

        private void PayThread()
        {
            string name = Thread.CurrentThread.Name;
            Console.WriteLine($"{name}, wait for Authorize");
            _paidEvent.WaitOne();
            Console.WriteLine($"{name} is released");
            Console.WriteLine($"{name} ends.");
        }


    }
}
