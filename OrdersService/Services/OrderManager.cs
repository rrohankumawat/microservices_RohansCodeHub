using Grpc.Core;
using OrdersService.protos;

namespace OrdersService.Services
{
    public class OrderManager
    {
        private readonly ProductProtoService.ProductProtoServiceClient _client;

        public OrderManager(
            ProductProtoService.ProductProtoServiceClient client)
        {
            _client = client;
        }

        public async Task<ProductResponse> GetProduct(int id)
        {
            
            var response = await _client.GetProductByIdAsync(
                new ProductRequest
                {
                    ProductId = id
                }
                );

            Console.WriteLine(response.Name);
            return response;
        }
    }
}
