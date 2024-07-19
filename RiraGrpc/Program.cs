using Microsoft.EntityFrameworkCore;
using Rira.Application;
using Rira.Application.Contract.Customer;
using Rira.Domain.CustomerAgg;
using Rira.Infrastructure.EFCore;
using Rira.Infrastructure.EFCore.Repository;
using RiraGrpc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CustomerContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("RiraProject")));

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerApplication, CustomerApplication>();



builder.Services.AddGrpc().AddJsonTranscoding();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<CustomerService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
