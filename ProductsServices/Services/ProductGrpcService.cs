using ProductsServices.protos;

namespace ProductsServices.Services
{
    public class ProductGrpcService : ProductProtoService.ProductProtoServiceBase
    {
        public async Task<ProductResponse> GetProductById (ProductRequest model)
        {
            var response = new ProductResponse()
            {
                ProductId = model.ProductId,
                Name = "Laptop",
                Price = 5000
            };

            return response;
        }
    }
}
