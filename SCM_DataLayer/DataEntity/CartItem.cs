using System.ComponentModel.DataAnnotations.Schema;

namespace SCM_DataLayer.DataEntity
{
    [Table("CartItem")]
    public class CartItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Cart")]
        public int IdCart { get; set; }
        public Cart Cart { get; set; }
      

    }
}
