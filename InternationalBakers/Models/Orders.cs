using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternationalBakers.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderLines = new HashSet<OrderLines>();
        }

        [Key]
        public int Id { get; set; }
        public DateTimeOffset? Date { get; set; }
        public double? Price { get; set; }
        [StringLength(150)]
        public string Status { get; set; }
        public int? StoreId { get; set; }

        [ForeignKey(nameof(StoreId))]
        [InverseProperty(nameof(Stores.Orders))]
        public virtual Stores Store { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
