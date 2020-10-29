using AutofacLifeTimeScopeDemo.Main.Model;
using AutofacLifeTimeScopeDemo.Main.Model.Model;
using AutofacLifeTimeScopeDemo.Main.Service.Handler;
using AutofacLifeTimeScopeDemo.Main.Service.Interface;
using System;
using System.Threading;

namespace AutofacLifeTimeScopeDemo.Main.Service.Impl
{
    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService : ITestService
    {
        private readonly DateTime TestDateTime;
        [Autowired]
        private TestHandler handler { set; get; }
        public TestService()
        {
            TestDateTime = DateTime.Now;
            Console.WriteLine($"【TestService】 Default Constructor Called");
            Console.WriteLine($"Thread    Id:{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"TestDateTime:{TestDateTime:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"DateTime Now:{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Thread.Sleep(2000);

        }
        public void Log(TestModel testModel)
        {
            Console.WriteLine($"【TestService】 Log Called");
            Console.WriteLine($"Thread    Id:{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"TestDateTime:{TestDateTime:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"DateTime Now:{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Thread.Sleep(2000);
            handler.Execute(new object());
        }
    }
}
