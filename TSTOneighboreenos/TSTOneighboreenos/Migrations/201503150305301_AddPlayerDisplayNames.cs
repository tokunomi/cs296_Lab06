namespace TSTOneighboreenos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlayerDisplayNames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Player", "NameFirst", c => c.String(maxLength: 50));
            AlterColumn("dbo.Player", "NameLast", c => c.String(maxLength: 50));
            AlterColumn("dbo.Player", "Email", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Player", "Email", c => c.String());
            AlterColumn("dbo.Player", "NameLast", c => c.String());
            AlterColumn("dbo.Player", "NameFirst", c => c.String());
        }
    }
}
