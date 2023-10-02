using ITWorxCourse.DAL.Entiities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorxCouurse.DAL.Entiities
{
    public class Products
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, 7000, ErrorMessage = "Price must be between 0 and 700.")]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
