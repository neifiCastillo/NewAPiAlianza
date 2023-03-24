using API_Alianza.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace API_Alianza
{
    public static class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //} 

        //public IConfiguration Configuration { get; }

        public static WebApplication InicializarAPP(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AlianzaDBContext>(options => options.UseSqlServer(builder.Configuration["Connnectionstrings:MyConnection"]));
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }

         private static void ConfigureServices(WebApplicationBuilder builder)
        {

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        private static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

        }

    }
}
