using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.Data.Models
{
    public class Cost
    {
        [Key]
        public int CostId { get; set; }
        public double Price { get; set; }
        public bool DiscountCode { get; set; }
    }

}
