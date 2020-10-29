using AutofacLifeTimeScopeDemo.Main.Service.Handler.Base;
using AutofacLifeTimeScopeDemo.Main.Service.Impl;
using System;
using System.Threading;

namespace AutofacLifeTimeScopeDemo.Main.Service.Handler
{
    internal class TestHandler : BaseHandle<object, Result>
    {
        private DateTime HandlerTestDateTime;

        public TestHandler() : base()
        {
            HandlerTestDateTime = DateTime.Now;
            Console.WriteLine($"【TestHandler】 Default Constructor Called");
            Console.WriteLine($"Thread    Id:{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"HandlerTestDateTime:{HandlerTestDateTime:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"DateTime       Now:{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Thread.Sleep(2000);
        }
        protected override void Init()
        {
            Console.WriteLine($"【TestHandler】 Init Called");
            Console.WriteLine($"Thread    Id:{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"HandlerTestDateTime:{HandlerTestDateTime:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"DateTime       Now:{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Thread.Sleep(2000);
        }

        protected override void RunExecute()
        {
            Console.WriteLine($"【TestHandler】 RunExecute Called");
            Console.WriteLine($"Thread    Id:{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"HandlerTestDateTime:{HandlerTestDateTime:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"DateTime       Now:{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Thread.Sleep(2000);
        }

        protected override void Validate()
        {
            Console.WriteLine($"【TestHandler】 Validate Called");
            Console.WriteLine($"Thread    Id:{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"HandlerTestDateTime:{HandlerTestDateTime:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"DateTime       Now:{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Thread.Sleep(2000);
        }

    }
}
