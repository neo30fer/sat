using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Data.Interfaces;
using Sat.Recruitment.Data.Repositories;
using Sat.Recruitment.Services;

namespace Sat.Recruitment.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
