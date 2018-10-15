using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace SportsStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please input a product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please input a description")]
        public string Description { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="Please input a price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please input a category")]
        public string Category { get; set; }
    }
}
