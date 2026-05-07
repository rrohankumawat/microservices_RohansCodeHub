using Grpc.Core;
using Grpc.Core.Interceptors;
using static Grpc.Core.Interceptors.Interceptor;

namespace OrdersService.Interceptors
{
    public class JwtInterceptor : Interceptor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtInterceptor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
            TRequest request,
            ClientInterceptorContext<TRequest, TResponse> context,
            AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            var token = _httpContextAccessor
                .HttpContext?
                .Request
                .Headers["Authorization"]
                .ToString();

            var headers = context.Options.Headers ?? new Metadata();

            if (!string.IsNullOrEmpty(token))
            {
                headers.Add("Authorization", token);
            }

            var newOptions = context.Options.WithHeaders(headers);

            var newContext = new ClientInterceptorContext<TRequest, TResponse>(
                context.Method,
                context.Host,
                newOptions);

            return continuation(request, newContext);
        }
    }
}
