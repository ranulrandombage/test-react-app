using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers.ASSAPI.Mappers
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
