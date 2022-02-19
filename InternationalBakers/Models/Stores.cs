using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternationalBakers.Models
{
    public partial class Stores
    {
        public Stores()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Country { get; set; }

        [InverseProperty("Store")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
