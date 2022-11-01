namespace AppVersioning.API.Middlewares;

public class CustomLogMiddleware
{
    private readonly RequestDelegate _next;

    public CustomLogMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        log4net.ThreadContext.Properties["URL"] = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
        log4net.ThreadContext.Properties["Method"] = context.Request.Method;
        log4net.ThreadContext.Properties["Enviroment"] = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        await _next(context);
    }
}
