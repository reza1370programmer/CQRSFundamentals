using Infrastructure.Orde.Repositories;
using Infrastructure.Orde;
using Ordering.Domain.AggregatesModel.BuyerAggregate;
using Ordering.Domain.AggregatesModel.OrderAggregate;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using Ordering.API.Infrastructure;
using Ordering.API.Application.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<OrderingContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString"]);
});
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IBuyerRepository, BuyerRepository>();
builder.Services.AddTransient<OrderingContextSeed>();
var connectionString = new
ConnectionString(builder.Configuration["ConnectionString"]);
 builder.Services.AddSingleton(connectionString);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{

    scope.ServiceProvider.GetService<OrderingContextSeed>()?.SeedAsync().Wait();
}
app.UseHttpsRedirection();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
