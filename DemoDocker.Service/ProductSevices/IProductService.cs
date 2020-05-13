using DemoDocker.Domain.Dtos;
using DemoDocker.Domain.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDocker.Service.ProductSevices
{
    public interface IProductService
    {
        public Task<PagedResult<ProductViewModel>> GetAllPaging(ProductPagingRequest request);

        public Task<List<ProductViewModel>> GetAll();

        public Task<int> Create(CreateProductRequest request);

        public Task<int> Update(UpdateProductRequest request);

        public Task<int> Delete(int productId);

        public Task<ProductViewModel> ProductDetail(int productId);

    }
}
