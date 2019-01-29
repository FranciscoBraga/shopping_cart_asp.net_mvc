using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SCM_DataLayer.DataEntity
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public DateTime DateAndTime { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
