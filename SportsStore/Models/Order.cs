using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;


namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage = "Please input a name")]
        [BindNever]
        public bool Shipped { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please input the first address line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Please input a City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please input a state name")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please input a country name")]
        public string Country { get; set; }
        public string GiftWrap { get; set; }
    }
}
