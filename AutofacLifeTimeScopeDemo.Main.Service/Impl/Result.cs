using AutofacLifeTimeScopeDemo.Main.Service.Interface;
using System;

namespace AutofacLifeTimeScopeDemo.Main.Service.Impl
{
    /// <summary>
    /// 基础结果返回
    /// </summary>
    public class Result : IResult
    {
        /// <summary>
        /// Result实例
        /// </summary>
        public Result()
        {
        }

        /// <summary>
        /// 使用异常信息初始化Result实例
        /// </summary>
        /// <param name="ex">异常信息</param>
        public Result(Exception ex)
        {
            Status = false;
            ErrorDetail = ex.StackTrace;
            Message = ex.Message;
        }

        /// <summary>
        /// 使用状态初始化Result实例
        /// </summary>
        /// <param name="status">状态</param>
        public Result(bool status)
        {
            Status = status;
        }

        /// <summary>
        /// 使用状态和消息初始化Result实例
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="message">消息</param>
        public Result(bool status, string message)
        {
            Status = status;
            Message = message;
        }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误详细
        /// </summary>
        public string ErrorDetail { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 返回TRUE
        /// </summary>
        /// <param name="message">消息</param>
        public static IResult True(string message = "")
        {
            return new Result()
            {
                Status = true,
                Message = message
            };
        }

        /// <summary>
        /// 返回FALSE
        /// </summary>
        /// <param name="message">消息</param>
        public static IResult False(string message = "")
        {
            return new Result()
            {
                Status = false,
                Message = message
            };
        }
    }

    /// <summary>
    /// 基础结果返回
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class Result<T> : IResult<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误详细
        /// </summary>
        public string ErrorDetail { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 返回TRUE
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        public static IResult<T> True(T data, string message = "")
        {
            return new Result<T>()
            {
                Status = true,
                Data = data,
                Message = message
            };
        }

        /// <summary>
        /// 返回FALSE
        /// </summary>
        /// <param name="message">消息</param>
        public static IResult<T> False(string message = "")
        {
            return new Result<T>()
            {
                Status = false,
                Message = message
            };
        }

        /// <summary>
        /// 返回FALSE
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        public static IResult<T> False(T data, string message = "")
        {
            return new Result<T>()
            {
                Status = false,
                Data = data,
                Message = message
            };
        }
    }
}
