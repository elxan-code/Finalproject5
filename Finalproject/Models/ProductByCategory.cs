using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Finalproject.Models
{
    public class ProductByCategory
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        
        public string Name { get; set; }
        [MaxLength(50)]
        public string Color { get; set; }
        [MaxLength(50)]
        public string Price { get; set; }
        [MaxLength(150)]
        public string Discount { get; set; }
        public DateTime DiscountDate { get; set; }



    }
}
