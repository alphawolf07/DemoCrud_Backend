using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Demo.Entites;

namespace Demo
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
            //var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("CrudConnection");
            builder.Services.AddDbContext<CrudDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddCors(options => {
                options.AddPolicy(name: "CORS",
                builder =>
                {
                    builder.AllowAnyHeader().WithOrigins("http://localhost:3000").AllowCredentials().AllowAnyMethod();
                });
            }
            );

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