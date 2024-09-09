using CatstgramApp.Filters;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using System.Text.Json.Serialization;

namespace CatstgramApp.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        
           {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFollowService, FollowService>();

            services.AddScoped<ICatService, CatService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ISearchService, SearchService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;

        }
        public static void AddApiControllers(this IServiceCollection services)
        {
            services.AddControllers(options => options.Filters
                        .Add<ModelOrNotFoundFilter>());
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }
           
        

    }
}
