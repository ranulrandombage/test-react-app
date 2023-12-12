using Mappers.ASSAPI.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.ASSAPI.Interfaces
{
    public interface IProductService
    {
        Task<ResponseDTO> AddProduct(ProductDTO product);
        Task<ResponseDTO> UpdateProduct(ProductDTO product);
        Task<ResponseDTO> GetAll();
    }
}
