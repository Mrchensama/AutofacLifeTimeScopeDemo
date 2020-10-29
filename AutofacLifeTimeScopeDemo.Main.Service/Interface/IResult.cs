namespace AutofacLifeTimeScopeDemo.Main.Service.Interface
{
    /// <summary>
    /// 基础结果返回
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        bool Status { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        string ErrorCode { get; set; }

        /// <summary>
        /// 错误详细
        /// </summary>
        string ErrorDetail { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        string Message { get; set; }
    }
    /// <summary>
    /// 基础结果返回
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IResult<T> : IResult
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        T Data { get; set; }
    }
}
