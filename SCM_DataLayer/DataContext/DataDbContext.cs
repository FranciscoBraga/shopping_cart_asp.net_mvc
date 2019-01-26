
using System.Data.Entity;
using SCM_DataLayer.DataEntity;

namespace SCM_DataLayer.DataContext
{
    public class DataDbContext:DbContext
    {
        public DataDbContext() : base("BDShoppingCart")
        {
        }

        public DbSet<Cart> Cart { get; set; }
    }
}
