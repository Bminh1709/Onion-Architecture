namespace WebApp.ServiceExtensions;

public static class ServiceExtensions
{
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
}
