using AutofacLifeTimeScopeDemo.Main.Model.Model;

namespace AutofacLifeTimeScopeDemo.Main.Service.Interface
{
    /// <summary>
    /// 测试服务接口定义
    /// </summary>
    public interface ITestService
    {
        /// <summary>
        /// 打印自身信息
        /// </summary>
        void Log(TestModel testModel);
    }
}
