
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Skorpion.GeneticsAI.Api.Data;
using Skorpion.GeneticsAI.Api.Helpers.Options;
using Skorpion.GeneticsAI.Api.Helpers;

namespace Skorpion.GeneticsAI.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Ensure.NotNullOrEmpty(connectionString);
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
            services.AddOptions<DatabaseOptions>()
                .Bind(configuration.GetSection(DatabaseOptions.SectionName))
                .ValidateDataAnnotations()
                .ValidateOnStart();
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
