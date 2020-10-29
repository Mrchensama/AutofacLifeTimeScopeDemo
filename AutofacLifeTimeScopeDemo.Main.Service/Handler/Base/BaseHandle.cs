using AutofacLifeTimeScopeDemo.Main.Service.Interface;
using System;
using System.Threading;

namespace AutofacLifeTimeScopeDemo.Main.Service.Handler.Base
{
    /// <summary>
    /// 业务处理抽象基类
    /// </summary>
    internal abstract class BaseHandle<TRequest, TResponse>
        where TRequest : new()
        where TResponse : IResult, new()
    {
        /// <summary>
        /// 请求参数
        /// </summary>
        protected TRequest request;

        /// <summary>
        /// 响应参数
        /// </summary>
        protected TResponse response;

        protected DateTime BaseHandleTestDate;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="request">请求参数</param>
        protected BaseHandle()
        {
            BaseHandleTestDate = DateTime.Now;
            Console.WriteLine($"【BaseHandle】 Default Constructor Called");
            Console.WriteLine($"Thread    Id:{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"BaseHandleTestDate:{BaseHandleTestDate:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"DateTime       Now:{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Thread.Sleep(2000);
            response = new TResponse
            {
                Status = true
            };
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <returns>执行结果</returns>
        public TResponse Execute(TRequest request)
        {
            try
            {
                Console.WriteLine($"【BaseHandle】 Execute Called");
                Console.WriteLine($"Thread    Id:{Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"BaseHandleTestDate:{BaseHandleTestDate:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine($"DateTime       Now:{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                Thread.Sleep(2000);
                this.request = request;
                //response = new TResponse
                //{
                //    Status = true
                //};
                Validate();
                if (!response.Status)
                {
                    return response;
                }

                Init();
                if (!response.Status)
                {
                    return response;
                }

                RunExecute();
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.ErrorDetail = ex.StackTrace;
            }

            return response;
        }

        /// <summary>
        /// 参数有效性验证
        /// </summary>
        /// <remarks>如果有其它必须传入的参数，请实现该函数</remarks>
        protected abstract void Validate();

        /// <summary>
        /// 初始化业务数据
        /// </summary>
        /// <remarks>如果有其它必须传入的参数，请重写该函数</remarks>
        protected abstract void Init();

        /// <summary>
        /// 执行业务罗辑由派生类实现
        /// </summary>
        /// <remarks>请实现该函数</remarks>
        protected abstract void RunExecute();
    }
}
