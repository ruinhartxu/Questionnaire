using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Products
    {

        [Key]
        public int ID { get; set; }
        [Index("ux_productName",2,IsUnique =true)]
        [MaxLength(255)]
        [Required]
        public string ProductName { get; set; }

        [Range(0,int.MaxValue)]
        [Required]
        public int Quantity { get; set; }
    }
}