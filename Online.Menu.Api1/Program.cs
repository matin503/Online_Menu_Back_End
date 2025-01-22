using Online.Menu.InfraStructure.Framework.Commons;
using Online.Menu.InfraStructure.Framework.ApiOptions;
using Online.Menu.Application;
using Scalar.AspNetCore;



var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

SettingCommon.AddJsonSettingFilesConfiguration();

services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null)
    .ConfigureApiBehaviorOptions(options => options.InvalidResponseFactory())
    .AddNewtonsoftJson();


services.AddResponseCompression();

services.AddApplicationServices(typeof(Program).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();

    app.MapScalarApiReference();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
