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
                x.SetDescription("������ѯ����--��Ϣ�������Ѷ�1.0.0.0");
                x.SetDisplayName("������ѯ����--�����߷���");
                x.SetServiceName("������ѯ����--�����߷���");
                //x.SetStartTimeout(new TimeSpan(200));
                x.StartAutomatically();
            });
        }
    }
}
