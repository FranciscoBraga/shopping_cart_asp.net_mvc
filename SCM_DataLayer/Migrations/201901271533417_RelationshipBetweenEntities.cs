namespace SCM_DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipBetweenEntities : DbMigration
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
                        IdCart = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cart", t => t.IdCart, cascadeDelete: true)
                .Index(t => t.IdCart);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Weight = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CartItem", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Id", "dbo.CartItem");
            DropForeignKey("dbo.CartItem", "IdCart", "dbo.Cart");
            DropIndex("dbo.Product", new[] { "Id" });
            DropIndex("dbo.CartItem", new[] { "IdCart" });
            DropTable("dbo.Product");
            DropTable("dbo.CartItem");
            RenameTable(name: "dbo.Cart", newName: "Carts");
        }
    }
}
