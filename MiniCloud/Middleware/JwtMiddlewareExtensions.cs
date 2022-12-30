namespace MiniCloud.Middleware
{
    public static class JwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomJwtMiddleware(this IApplicationBuilder builder) 
        { 
            return builder.UseMiddleware<JwtMiddleware>();
        }
    }
}
