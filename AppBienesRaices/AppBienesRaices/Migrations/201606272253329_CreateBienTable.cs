namespace AppBienesRaices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBienTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bien",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Boolean(nullable: false, defaultValue: false),
                        City = c.String(maxLength: 25, defaultValue: ""),
                        Adress = c.String(),
                        DateWhenPublish = c.String(maxLength: 12, defaultValue: ""),
                        OriginalPrice = c.Double(nullable: false, defaultValue: 0),
                        NewPrice = c.Double(nullable: false, defaultValue: 0),
                        ImageUrl = c.String(maxLength: 255, defaultValue: ""),
                })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bien");
        }
    }
}
