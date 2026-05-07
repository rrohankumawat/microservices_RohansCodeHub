using Grpc.Core;
using Grpc.Core.Interceptors;

namespace OrdersService.Interceptors
{
    public class JwtInterceptors : Interceptor
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public JwtInterceptors(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }


        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, 
            ClientInterceptorContext<TRequest, TResponse> context, 
            AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            var token = _contextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

            var headers = context.Options.Headers ?? new Metadata();

            if(!string.IsNullOrEmpty(token) )
            {
                headers.Add("Authorization", token);    
            }


            var newOptions = context.Options.WithHeaders(headers);


            var clientInterceptors = new ClientInterceptorContext<TRequest, TResponse>(context.Method, context.Host, newOptions);

            return continuation(request, clientInterceptors);
        }
    }
}
