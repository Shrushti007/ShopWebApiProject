using Microsoft.EntityFrameworkCore;
using ShopWebApiProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string ConString = builder.Configuration.GetConnectionString("ShopDB");
builder.Services.AddDbContext<ShopeDbContext>(o => o.UseMySql(ConString, ServerVersion.AutoDetect(ConString)));
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
