using Microsoft.EntityFrameworkCore;
using PicPayApiChallenge.Data.Context;
using PicPayApiChallenge.Domain.Services;
using PicPayApiChallenge.Data.Repositories;
using Microsoft.OpenApi.Models;
using PicPayApiChallenge.Domain.Contracts.Repositories;
using PicPayApiChallenge.Domain.Contracts.Services;
using PicPayApiChallenge.Domain.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add controllers to the container.
builder.Services.AddControllers();

// Add Repositories to the container.
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();

// Add service to the container.
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITransactionService, TransactionService>();
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.Configure<Logging>(builder.Configuration.GetSection("Logging"));
builder.Services.Configure<ExternalUrls>(builder.Configuration.GetSection("ExternalUrls"));

// Add data base context to the container.
builder.Services.AddDbContext<SqlContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Pic Pay Api Challenge", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
