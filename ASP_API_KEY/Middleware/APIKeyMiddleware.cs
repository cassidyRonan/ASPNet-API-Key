namespace ASP_API_KEY.Middleware
{
    /// <summary>
    /// This middleware will check the API key in the header and validate the key by extracting it from the header and compare the key defined in code.
    /// </summary>
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY = "ApiKey";

        public APIKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Request.Headers.TryGetValue(API_KEY, out var extractedKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key was not provided");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(API_KEY);
            if (!apiKey.Equals(extractedKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }
            await _next(context);
        }
    }
}
