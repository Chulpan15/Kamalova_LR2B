using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Kamalova_LR2B.Models;


namespace Kamalova_LR2B
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           // string cs = Server = myServerAddress; Database = myDataBase; User Id = Chulpan15; Password = Chulpan15;
            builder.Services.AddDbContext<AuthorsContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("AuthorsContext")));

            // Add services to the container.

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