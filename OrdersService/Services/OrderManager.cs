using OrdersService.protos;

namespace OrdersService.Services
{
    public class OrderManager
    {
        private readonly ProductProtoService.ProductProtoServiceClient _serviceClient;

        public OrderManager(ProductProtoService.ProductProtoServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public async Task<ProductResponse> GetProductById(int id)
        {
            var response = await _serviceClient.GetProductByIdAsync(new ProductRequest { ProductId = id});

            return response;
        }
    }
}
