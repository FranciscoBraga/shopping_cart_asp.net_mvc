namespace SCM_DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewRelationship : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Carts", newName: "Cart");
            CreateTable(
                "dbo.CartItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cart", t => t.Cart_Id)
                .Index(t => t.Cart_Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItem", "Cart_Id", "dbo.Cart");
            DropIndex("dbo.CartItem", new[] { "Cart_Id" });
            DropTable("dbo.Product");
            DropTable("dbo.CartItem");
            RenameTable(name: "dbo.Cart", newName: "Carts");
        }
    }
}
