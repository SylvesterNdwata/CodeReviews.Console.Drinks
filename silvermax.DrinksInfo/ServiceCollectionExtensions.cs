using Microsoft.Extensions.DependencyInjection;

namespace silvermax.DrinksInfo;

public static class ServiceCollectionExtensions
{
    public static ServiceProvider ServiceProvider(this IServiceCollection services)
    {
        services.AddHttpClient<DrinksClient>(c => c.BaseAddress = new Uri("http://www.thecocktaildb.com/api/json/v1/1/"));
        services.AddTransient<DrinksService>();

        return services.BuildServiceProvider();
    }
}
