using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SeafoodInventoryAPI.Models;

namespace SeafoodInventoryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // configure DBContext to use SQL Server
            builder.Services.AddDbContext<SeafoodDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SeafoodDbConnection")));

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthorization();

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
