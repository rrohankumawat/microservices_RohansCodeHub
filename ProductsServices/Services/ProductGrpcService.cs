using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using ProductsServices.protos;

namespace ProductsServices.Services
{
    [Authorize]
    public class ProductGrpcService
    : ProductProtoService.ProductProtoServiceBase
    {
        public override Task<ProductResponse> GetProductById(
            ProductRequest request,
            ServerCallContext context)
        {
            var response = new ProductResponse
            {
                ProductId = request.ProductId,
                Name = "Laptop",
                Price = 55000
            };

            return Task.FromResult(response);
        }
    }
}
