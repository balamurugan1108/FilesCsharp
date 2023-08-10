using BusinessLogicLayer;
using DataLayer;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FIle_Json
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connection = builder.Configuration.GetConnectionString("Database");
            builder.Services.AddDbContextPool<JsonDbContext>(option => option.UseSqlServer(connection));
            builder.Services.AddScoped<IDataLayerCls, DataLayerCls>();
            builder.Services.AddScoped<ILogicLayer, LogicLayer>();
            builder.Services.AddControllers();
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
        }
    }
}