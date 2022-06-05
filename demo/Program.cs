
using Autofac;
using Autofac.Extensions.DependencyInjection;
using demo;
using demo.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModuleRegister());
    });

// Add services to the container.
//builder.Services.
builder.Services.AddControllers();
builder.Services.AddHostedService<AppHostedServ>();
builder.Services.AddDbContext<DemoContext>(opts =>
{
    opts.UseSqlite("Data Source=app.db");
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

