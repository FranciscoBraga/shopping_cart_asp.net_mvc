namespace SCM_DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipBetweenCartItemAndProducts : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CartItem");
            AlterColumn("dbo.CartItem", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CartItem", "Id");
            CreateIndex("dbo.CartItem", "Id");
            AddForeignKey("dbo.CartItem", "Id", "dbo.Product", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItem", "Id", "dbo.Product");
            DropIndex("dbo.CartItem", new[] { "Id" });
            DropPrimaryKey("dbo.CartItem");
            AlterColumn("dbo.CartItem", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CartItem", "Id");
        }
    }
}
