using AutofacLifeTimeScopeDemo.Main.Model;
using AutofacLifeTimeScopeDemo.Main.Model.Model;
using AutofacLifeTimeScopeDemo.Main.Service.Interface;
using Quartz;
using System;
using System.Threading.Tasks;

namespace AutofacLifeTimeScopeDemo.Main.Job
{
    [DisallowConcurrentExecution]
    public class QuestionJob : IJob
    {
        [Autowired]
        private TopicHandle _topicHandle { set; get; }
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"开始工作：{DateTime.Now}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"第{i + 1}次循环，开始：{DateTime.Now}");
                _topicHandle.Handle(new TestModel()
                {
                    Id = i
                });
                Console.WriteLine($"第{i + 1}次循环，结束：{DateTime.Now}");
            }
            Console.WriteLine($"结束工作：{DateTime.Now}");
            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// 获取咨询队列消息
    /// </summary>
    public class TopicHandle
    {
        [Autowired]
        private ITestService _testService { set; get; }
        /// <summary>
        /// 获取队列内容
        /// </summary>
        /// <returns></returns>
        public void Handle(TestModel topic)
        {
            if (topic != null)
            {
                //更新咨询内容业务
                _testService.Log(topic);
                //Console.WriteLine($"执行状态：咨询({topic.Id}-{result.State})，{(result.State == (int)EnumApiResultState.OK ? "执行成功！" : "错误消息：" + result.Message)}");
            }
            else
            {
                Console.WriteLine("无数据需要处理！");
            }
        }
    }
}