using EnsekTest.Data;
using EnsekTest.Data.Entities;
using EnsekTest.Services.Implementations;
using EnsekTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.AddDbContext<EnsekTestContext>(options =>
{    
    options.UseSqlServer("Data Source=.\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=EnsekTest;MultipleActiveResultSets=true;TrustServerCertificate=true", opts =>
    {
        opts.MigrationsAssembly("EnsekTest.Data");
    });
});    

builder.Services.AddTransient(typeof(IMeterReadingService), typeof(MeterReadingService));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
