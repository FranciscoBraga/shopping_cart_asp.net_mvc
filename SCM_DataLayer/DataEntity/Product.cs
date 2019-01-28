using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SCM_DataLayer.DataEntity
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public CartItem CartItem { get; set; }


    }
}
