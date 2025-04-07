namespace net2_quiz2_დავით_ჭელიძეwebapi
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            Console.WriteLine($"Request Path: {httpContext.Request.Path}, Method: {httpContext.Request.Method}");
            await _next(httpContext);
        }
    }

}
