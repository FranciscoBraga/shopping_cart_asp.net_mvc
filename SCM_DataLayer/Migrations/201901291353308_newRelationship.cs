namespace SCM_DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItem", "CarItemId", "dbo.Product");
            DropColumn("dbo.CartItem", "ProductId");
            RenameColumn(table: "dbo.CartItem", name: "CarItemId", newName: "ProductId");
            RenameIndex(table: "dbo.CartItem", name: "IX_CarItemId", newName: "IX_ProductId");
            DropPrimaryKey("dbo.CartItem");
            AddColumn("dbo.CartItem", "CartItemId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CartItem", "CartItemId");
            AddForeignKey("dbo.CartItem", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItem", "ProductId", "dbo.Product");
            DropPrimaryKey("dbo.CartItem");
            DropColumn("dbo.CartItem", "CartItemId");
            AddPrimaryKey("dbo.CartItem", "CarItemId");
            RenameIndex(table: "dbo.CartItem", name: "IX_ProductId", newName: "IX_CarItemId");
            RenameColumn(table: "dbo.CartItem", name: "ProductId", newName: "CarItemId");
            AddColumn("dbo.CartItem", "ProductId", c => c.Int(nullable: false));
            AddForeignKey("dbo.CartItem", "CarItemId", "dbo.Product", "ProductId");
        }
    }
}
