using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using ProductsServices.protos.v2;
namespace ProductsServices.Services

{
    public class ProductGrpcService_v2 : ProductProtoService.ProductProtoServiceBase
    {
        [Authorize]
        public class ProductGrpcService : ProductProtoService.ProductProtoServiceBase
        {
            public override async Task<ProductResponse> GetProductById(ProductRequest model, ServerCallContext context)
            {

                var response = new ProductResponse
                {
                    ProductId = model.ProductId,
                    Name = "Laptop",
                    Price = 5000,
                    Description = "Electronic Item"
                };

                return response;
            }
        }
    }
}
