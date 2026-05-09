using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using ProductsServices.protos;

namespace ProductsServices.Services
{
    [Authorize]
    public class ProductGrpcService : ProductProtoService.ProductProtoServiceBase
    {
        public override async Task<ProductResponse> GetProductById(ProductRequest model, ServerCallContext context)
        {

            var response = new ProductResponse { 
                ProductId = model.ProductId,
                Name = "Laptop",
                Price = 5000
            };

            return response;
        }
    }
}
