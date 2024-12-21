using Application.Common.Interfaces.Authentication;
using Application.Common.Services;
using Infrastructure.Authentication;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        return services
            .Configure<JwtSettings>(builderConfiguration.GetSection(JwtSettings.SECTION_NAME)) 
            .AddSingleton<IJwtTokenGenerate, JwtTokenGenerate>()
            .AddSingleton<IDateTimeProvider, DateTimeProvider>();
    }
}