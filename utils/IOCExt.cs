using Autofac.Extensions.DependencyInjection;
using Autofac;
using System.Reflection;

namespace WebReadSite.utils
{
    /// <summary>
    /// IOC扩展
    /// </summary>
    public static class IOCExt
    {
        /// <summary>
        /// 添加IOC
        /// </summary>
        /// <param name="builder"></param>
        public static void AddIoc(this WebApplicationBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;
            var servicesDllFile = Path.Combine(basePath, "Service.dll"); //服务层
            if (!(File.Exists(servicesDllFile) ))
            {
                throw new Exception("service.dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。");
            }
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(build =>
            {
                // 获取 Service.dll 程序集服务，并注册
                var assemblysRepository = Assembly.LoadFrom(servicesDllFile);
                build.RegisterAssemblyTypes(assemblysRepository)
                        .AsImplementedInterfaces()
                        .InstancePerDependency();
            });
        }
    }
}
