
using CatstgramApp.Extensions;
using CatstgramApp.Filters;
using CatstgramApp.Helper;
using Infrastructure.Data.Identity;
using Microsoft.EntityFrameworkCore;

namespace CatstgramApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddApiControllers();            
            builder.Services.IdentityServices(builder.Configuration);
            builder.Services.AddDbContext<CatstgramDbContext>(
          options =>
          {
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
          }
          );
            builder.Services.AddApplicationServices();
            builder.Services.AddSwaggerDocServices();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(c => c.AddPolicy("CorsPolicy", c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => true)));

            builder.Services.AddAutoMapper(typeof(ProfileMapping));
            builder.Services.AddAutoMapper(typeof(Infrastructure.Helper.ProfileMapping));

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
            app.UseCors("CorsPolicy");
            app.Run();
        }
    }
}
