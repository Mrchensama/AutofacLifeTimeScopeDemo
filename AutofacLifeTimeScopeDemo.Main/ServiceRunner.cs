using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using AutofacLifeTimeScopeDemo.Main.Job;
using AutofacLifeTimeScopeDemo.Main.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.IO;
using System.Reflection;
using Topshelf;

namespace AutofacLifeTimeScopeDemo.Main
{
    /// <summary>
    /// 服务启动
    /// </summary>
    public class ServiceRunner : ServiceControl
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceRunner()
        {
            var configurationRoot = ConfigureConfiguration();
            _serviceProvider = ConfigureServices(configurationRoot);
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
        private IConfiguration ConfigureConfiguration()
        {
            //appSetting
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            return builder.Build();
        }

        private IServiceProvider ConfigureServices(IConfiguration configuration)
        {
            //依赖注入
            IServiceCollection services = new ServiceCollection();
            //log注入
            //services.AddTransient<ILoggerFactory, LoggerFactory>();
            services.AddScoped<IJobFactory, QuartzJobFactory>();
            if (configuration != null)
            {
                services.AddSingleton(configuration);
            }

            ////job注入
            //services.AddScoped<QuestionJob>();
            services.AddSingleton(service =>
            {
                var scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
                scheduler.JobFactory = service.GetService<IJobFactory>();
                return scheduler;
            });
            ContainerBuilder builder = new ContainerBuilder();
            //业务层Handle
            builder.RegisterAssemblyTypes(Assembly.Load("AutofacLifeTimeScopeDemo.Main.Service"))
                .Where(t => t.Name.EndsWith("Handler"))
                .AsSelf()
                .InstancePerDependency()
                .PropertiesAutowired(new HuaLvPropertySelector(), true);
            //业务层Service
            builder.RegisterAssemblyTypes(Assembly.Load("AutofacLifeTimeScopeDemo.Main.Service"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired(new HuaLvPropertySelector(), true);
            //handle
            builder.RegisterAssemblyTypes(Assembly.Load("AutofacLifeTimeScopeDemo.Main"))
                .Where(t => t.Name.EndsWith("Handle"))
                .AsSelf()
                .InstancePerDependency()
                .PropertiesAutowired(new HuaLvPropertySelector(), true);
            //新模块组件注册
            builder.RegisterType<QuestionJob>()
                .As<QuestionJob>()
                .InstancePerDependency()
                .PropertiesAutowired(new HuaLvPropertySelector(), true);
            //将services中的服务填充到Autofac中.
            builder.Populate(services);
            //创建容器.
            var autofacContainer = builder.Build();
            //使用容器创建 AutofacServiceProvider 
            return new AutofacServiceProvider(autofacContainer);
        }

        /// <summary>
        /// 启动消费
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns>执行是否成功</returns>
        public bool Start(HostControl hostControl)
        {
            var scheduler = _serviceProvider.GetService(typeof(IScheduler)) as IScheduler;
            scheduler?.Start();
            return true;
        }

        /// <summary>
        /// 停止消费
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns>执行是否成功</returns>
        public bool Stop(HostControl hostControl)
        {
            var scheduler = _serviceProvider.GetService(typeof(IScheduler)) as IScheduler;
            scheduler?.Shutdown(true);
            return true;
        }
    }
    /// <summary>
    /// 依赖注入-属性注入华律自定义选择器
    /// </summary>
    internal class HuaLvPropertySelector : IPropertySelector
    {
        /// <summary>
        /// 是否注入属性
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            if (propertyInfo.GetCustomAttribute<Autowired>(false) == null)
            {
                return false;
            }
            return true;
        }
    }
}
