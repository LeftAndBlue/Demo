using Newtonsoft.Json.Serialization;
using ReadSite.util;
using WebReadSite.utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
/*Json��ʽ��*/
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
});
// ���� CORS ����
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .AllowAnyOrigin()// �����ǰ�˵�ַ
            .AllowAnyMethod()
            .AllowAnyHeader());
});
/*Swagger����*/
builder.Services.AddSwaggerExt();
/*IOC����*/
builder.AddIoc();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwaggerExt();
//}
app.UseSwaggerExt();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");
app.Run();
