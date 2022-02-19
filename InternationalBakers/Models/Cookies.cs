using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternationalBakers.Models
{
    public partial class Cookies
    {
        public Cookies()
        {
            OrderLines = new HashSet<OrderLines>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(150)]
        public string ImageUrl { get; set; }
        public double? Price { get; set; }

        [InverseProperty("Cookie")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
