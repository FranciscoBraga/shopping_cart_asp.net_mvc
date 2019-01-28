using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SCM_DataLayer.DataEntity
{
    [Table("CartItem")]
    public class CartItem
    {
        [Key,ForeignKey("Product")]
        public int Id { get; set; }
        public int Amount { get; set; }
        public virtual Cart Cart { get; set; }
        public Product Product { get; set; }



    }
}
