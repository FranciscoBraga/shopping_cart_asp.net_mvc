using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCM_DataLayer.DataEntity
{
    [Table("Cart")]
    public class Cart
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
