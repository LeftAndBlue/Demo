using System.Reflection;
using Microsoft.OpenApi.Models;
namespace ReadSite.util;
/// <summary>
/// Swagger扩展
/// </summary>
public static class SwaggerExt
{
    /// <summary>
    /// 添加Swagger扩展
    /// </summary>
    /// <param name="services"></param>
    public static void AddSwaggerExt(this IServiceCollection services)
    {
        //
        services.AddSwaggerGen(c =>
        {
            /*版本控制*/
            typeof(ApiVersion).GetEnumNames().ToList().ForEach(version =>
            {
                c.SwaggerDoc(version, new OpenApiInfo { Title = "WebRead Api", Version = version });
            });
            /*添加注释*/
            var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }
    /// <summary>
    /// 使用Swagger扩展
    /// </summary>
    /// <param name="application"></param>
    public static void UseSwaggerExt(this WebApplication application)
    {
        application.UseSwagger();
        application.UseSwaggerUI(c =>
        {
            foreach (var item in typeof(ApiVersion).GetEnumNames())
            {
                c.SwaggerEndpoint($"/swagger/{item}/swagger.json", $"WebAread Api {item}版本");
            }
        });
    }
}