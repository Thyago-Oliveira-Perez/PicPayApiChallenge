using Microsoft.EntityFrameworkCore;
using PicPayApiChallenge.Data.Context;
using PicPayApiChallenge.Domain.Services;
using PicPayApiChallenge.Domain.Interfaces;
using PicPayApiChallenge.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add controllers to the container.
builder.Services.AddControllers();

// Add Repositories to the container.
builder.Services.AddTransient<ICommonUserRepository, CommonUserRepository>();
builder.Services.AddTransient<ITradesmanRepository, TrandesmanRepository>();

// Add service to the container.
builder.Services.AddTransient<ITransactionService, TransactionService>();

// Add data base context to the container.
builder.Services.AddDbContext<SqlContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
