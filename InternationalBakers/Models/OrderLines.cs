using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternationalBakers.Models
{
    public partial class OrderLines
    {
        [Key]
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public int? CookieId { get; set; }
        public int? OrderId { get; set; }

        [ForeignKey(nameof(CookieId))]
        [InverseProperty(nameof(Cookies.OrderLines))]
        public virtual Cookies Cookie { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(Orders.OrderLines))]
        public virtual Orders Order { get; set; }
    }
}
