using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace SCM_DataLayer.DataEntity
{
    [Table("Product")]
    public class Product
    {
       
        [Key]
        public int ProductId { get; set; }
        public string  Name { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; } 


    }
}
