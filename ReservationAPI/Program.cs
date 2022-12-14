using Microsoft.EntityFrameworkCore;
using ReservationAPI.Data;
using ReservationAPI.Data.Interfaces;
using ReservationAPI.Data.MySqlRepos;
using ReservationAPI.Models;

namespace ReservationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(op => {
                var cs = builder.Configuration.GetConnectionString("Default");
                op.UseMySql(cs, ServerVersion.AutoDetect(cs));
            });
            builder.Services.AddScoped<IMenuItemRepo, MySqlMenuItemRepo>();
            builder.Services.AddScoped<IOrderRepo, MySqlOrderRepo>();

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