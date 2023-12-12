using DATA.ASSAPI.DBContext;
using DATA.ASSAPI.Models;
using Interfaces.ASSAPI.Interfaces;
using KeenCleaner.Service.RepositoryPattern;
using Mappers.ASSAPI.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services.ASSAPI.Services
{
    public class ProductService: IProductService
    {
        private readonly ApplicationDbContext _dbContext;
        private IRepository<Product> _repositoryProduct;


        public ProductService(ApplicationDbContext dbContext, IRepository<Product> repositoryProduct)
        {
            _dbContext = dbContext;
            _repositoryProduct = repositoryProduct;
        }

        public async Task<ResponseDTO> AddProduct(ProductDTO product)
        {
            ResponseDTO response = new ResponseDTO();
            var dbTransaction = _dbContext.Database;

            try
            {
                Product producteNew = new() { Name = product.Name, Price = product.Price, CreatedDate = DateTime.Now};

                dbTransaction.BeginTransaction();
                var res = await _repositoryProduct.InsertAsync(producteNew);
                dbTransaction.CommitTransaction();
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                dbTransaction.RollbackTransaction();
                response.ErrorMessage = ex.ToString();
                response.IsSuccess = false;
                return response;
            }
        }

        public async Task<ResponseDTO> UpdateProduct(ProductDTO product)
        {
            ResponseDTO response = new ResponseDTO();
            var dbTransaction = _dbContext.Database;

            try
            {
                Product producteNew = new() {Id = product.Id, Name = product.Name, Price = product.Price };

                dbTransaction.BeginTransaction();
                var res = await _repositoryProduct.UpdateAsync(producteNew);
                dbTransaction.CommitTransaction();
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                dbTransaction.RollbackTransaction();
                response.ErrorMessage = ex.ToString();
                response.IsSuccess = false;
                return response;
            }
        }

        public async Task<ResponseDTO> GetAll()
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                List<Product> productList = await _repositoryProduct.Products.Where(x => x.IsActive == true).ToListAsync();
                response.IsSuccess = true;
                response.Data = productList;
                return response;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.ToString();
                response.IsSuccess = false;
                return response;
            }
        }
    }
}
