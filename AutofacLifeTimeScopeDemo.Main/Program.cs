using Topshelf;

namespace AutofacLifeTimeScopeDemo.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ServiceRunner>();
                x.SetDescription("公开咨询发布--消息总线消费端1.0.0.0");
                x.SetDisplayName("公开咨询发布--消费者服务");
                x.SetServiceName("公开咨询发布--消费者服务");
                //x.SetStartTimeout(new TimeSpan(200));
                x.StartAutomatically();
            });
        }
    }
}
