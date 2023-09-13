namespace CustomMiddleware
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Threading.Tasks;

    public static class ExceptionHandler
    {
        public static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "An error occurred while processing your request.",
                ExceptionMessage = exception.Message
            });
        }
    }

}
