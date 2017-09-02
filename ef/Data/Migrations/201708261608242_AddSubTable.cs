namespace ef.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainTableId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainTable", t => t.MainTableId, cascadeDelete: true)
                .Index(t => t.MainTableId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubTable", "MainTableId", "dbo.MainTable");
            DropIndex("dbo.SubTable", new[] { "MainTableId" });
            DropTable("dbo.SubTable");
        }
    }
}
