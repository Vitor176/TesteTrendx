using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ToDoListAPI.ExceptionFilter
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var errorResponse = new
                {
                    BusinessError = true,
                    ShowErrorMessage = true,
                    ErrorMessage = ex.Message
                };

                var jsonErrorResponse = JsonConvert.SerializeObject(errorResponse);
                await context.Response.WriteAsync(jsonErrorResponse);
            }
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
