using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.ASSAPI.Models
{
    [Table("Product")]
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
