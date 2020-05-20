using Dapper;
using DemoDocker.Domain.Data.Product;
using DemoDocker.Domain.Dtos;
using DemoDocker.Domain.Dtos.Common;
using DemoDocker.Infastructure.EF;
using DemoDocker.Service.ProductSevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDocker.Services
{
    public class ProductService : IProductService
    {
        private readonly DemoDbContext _context;
        private readonly IDbConnection _connection;

        public ProductService(DemoDbContext context, IDbConnection dbConnection)
        {
            _context = context;
            _connection = dbConnection;
        }

        public async Task<int> Create(CreateProductRequest request)
        {

            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                SeoAlias = request.SeoAlias,
                DateCreated = DateTime.Now
            };

            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return 0;
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }


        public async Task<PagedResult<ProductViewModel>> GetAllPaging(ProductPagingRequest request)
        {
            //// select
            //var query = from p in _context.Products
            //            select p;
            //// Filter
            //if (string.IsNullOrEmpty(request.KeyWord))
            //{
            //    query.Where(x => x.Name.Contains(request.KeyWord));
            //}

            //var rowCount = await query.CountAsync();

            //// Paging
            //var data = await query.Skip((request.pageIndex - 1) * request.pageSize).Take(request.pageSize).
            //    Select(x => new ProductViewModel
            //    {
            //        Id = x.Id,
            //        Description = x.Description,
            //        Price = x.Price,
            //        Name = x.Name,
            //        SeoAlias = x.SeoAlias,
            //        DateCreated = x.DateCreated

            //    }).ToListAsync();

            //var pageCount = (int)Math.Ceiling(rowCount /(double)request.pageSize);
            //var pagedResult = new PagedResult<ProductViewModel>()
            //{
            //    Items = data,
            //    TotalRecord = rowCount,
            //    PageCount = pageCount
            //};

            //return pagedResult;
            var query = (@"SELECT * FROM ""Products""");
            if ((!string.IsNullOrEmpty(request.KeyWord)))
            {
                query = query + (" Where Name = @Name");
            }

            var product = await _connection.QueryAsync<ProductViewModel>(query, new { Name = request.KeyWord });

            query = query + ("  OFFSET   @Offset ROWS FETCH NEXT  @Next  ROWS ONLY");

            var productVm = await _connection.QueryAsync<ProductViewModel>(query, new {  Offset = request.pageIndex - 1, Next = request.pageSize, });

            var pagedResult = new PagedResult<ProductViewModel>()
            {
                Items = productVm,
                PageCount = (int)Math.Ceiling(product.Count() / (double)request.pageSize)
            };

            return pagedResult;
        }

        //public async Task<ProductViewModel> GetAllPaging(int pageIndex, int pageSize, string Keyword)
        //{
        //    var query = from p in _context.Products
        //                  select p;
        //    if (string.IsNullOrEmpty(Keyword))
        //    {
        //        query.Where(x => x.Name.Contains(Keyword));
        //    }

        //    var rowCount = await query.CountAsync();

        //    // Paging
        //    await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();



        //}

        public async Task<int> Update(UpdateProductRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);

            if (product == null)
            {
                return 0;
            }
            // Set data
            product.Name = request.Name;
            product.SeoAlias = request.SeoAlias;
            product.Description = request.Description;
            product.DateCreated = request.DateCreated;
            product.Price = request.Price;
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductViewModel> ProductDetail(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null)
            {
                return null;
            }

            var productVm = new ProductViewModel()
            {
                Name = product.Name,
                Price = product.Price,
                DateCreated = product.DateCreated,
                Description = product.Description,
                Id = product.Id,
                SeoAlias = product.SeoAlias
            };

            return productVm;
        }

        public Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
