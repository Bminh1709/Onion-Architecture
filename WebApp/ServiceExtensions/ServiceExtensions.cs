using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Service.Contracts;

namespace WebApp.ServiceExtensions;

public static class ServiceExtensions
{
    // Mechanism to give or restrict access rights to applications from different domains
    public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin() // allows requests from any source
                                     // Or WithOrigins("https://example.com")
            .AllowAnyMethod() // allows all HTTP methods
                              // Or WithMethods("POST", "GET")
            .AllowAnyHeader()); // allow all headers
                                // WithHeaders("accept", "contenttype")
    });

    // Host our application on IIS for deployment
    public static void ConfigureIISIntegration(this IServiceCollection services) => services.Configure<IISOptions>(options =>
    {
    });

    // Add the logger service
    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureSqlContext(this IServiceCollection services,
        IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
        opts.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
}