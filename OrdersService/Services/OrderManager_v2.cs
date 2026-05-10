using Grpc.Net.ClientFactory;
using OrdersService.protos.v2;
namespace OrdersService.Services
{
    public class OrderManager_v2
    {
        private readonly ProductProtoService.ProductProtoServiceClient _serviceClient;

        public OrderManager_v2(GrpcClientFactory factory )
        {
            _serviceClient = factory.CreateClient<
            OrdersService.protos.v2.ProductProtoService.ProductProtoServiceClient>("ProductV2");
        }

        public async Task<ProductResponse> GetProductById(int id)
        {
            var response = await _serviceClient.GetProductByIdAsync(new ProductRequest { ProductId = id });

            return response;
        }
    }
}
