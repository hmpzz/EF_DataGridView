namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        order_no = c.String(nullable: false, maxLength: 50),
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.order_no);
            
            CreateTable(
                "dbo.Order_History",
                c => new
                    {
                        order_no = c.String(nullable: false, maxLength: 50),
                        History_Date = c.DateTime(nullable: false),
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.order_no, t.History_Date });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Order_History");
            DropTable("dbo.Order");
        }
    }
}
