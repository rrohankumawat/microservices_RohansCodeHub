using Grpc.Core;
using ProductsServices.protos;

namespace ProductsServices.Services
{
    public class ProductGrpcService : ProductProtoService.ProductProtoServiceBase
    {
        public override Task<ProductResponse> GetProductById (ProductRequest model, ServerCallContext context)
        {

            var response = new ProductResponse { 
                ProductId = model.ProductId,
                Name = "Laptop",
                Price = 5000
            };

            return Task.FromResult(response);

        }
    }
}
