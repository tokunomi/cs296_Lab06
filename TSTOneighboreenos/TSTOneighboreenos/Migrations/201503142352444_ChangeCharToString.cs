namespace TSTOneighboreenos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCharToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "MidInit", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "MidInit");
        }
    }
}
