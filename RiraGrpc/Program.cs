using Microsoft.EntityFrameworkCore;
using Rira.Infrastructure.EFCore;
using RiraGrpc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<CustomerContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("RiraProject")));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
