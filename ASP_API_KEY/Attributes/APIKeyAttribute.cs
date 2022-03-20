using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASP_API_KEY.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class APIKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string API_KEY = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(API_KEY, out var extractedKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = " API Key was not provided"
                };
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(API_KEY);

            if (!apiKey.Equals(extractedKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = " API Key was not provided"
                };
                return;
            }

            await next();
        }
    }
}
