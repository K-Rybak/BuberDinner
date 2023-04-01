using Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
                .AddScoped<IAuthenticationService, AuthenticationService>();
        } 
    }
}
