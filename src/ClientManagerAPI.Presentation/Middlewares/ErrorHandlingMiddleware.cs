using System.Net;
using System.Text.Json;

namespace ClientManagerAPI.Presentation.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var error = new { message = ex.Message };
            await response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}
