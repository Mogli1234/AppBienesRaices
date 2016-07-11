namespace AppBienesRaices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateContactsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contactos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        Mensaje = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contactos");
        }
    }
}
