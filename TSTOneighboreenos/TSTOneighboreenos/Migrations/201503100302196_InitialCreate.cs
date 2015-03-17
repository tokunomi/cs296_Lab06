namespace TSTOneighboreenos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friend",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlayerID = c.Int(nullable: false),
                        NeighborID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Neighbor", t => t.NeighborID, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.PlayerID)
                .Index(t => t.NeighborID);
            
            CreateTable(
                "dbo.Neighbor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TSTOhandle = c.String(),
                        Level = c.Int(nullable: false),
                        SpringfieldPath = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TSTOhandle = c.String(),
                        Level = c.Int(nullable: false),
                        NameFirst = c.String(),
                        NameLast = c.String(),
                        Email = c.String(),
                        SpringfieldPath = c.String(),
                        Active = c.Boolean(nullable: false),
                        AddMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Gallery",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImgPath = c.String(),
                        Title = c.String(),
                        Desc = c.String(),
                        Abandon = c.Boolean(nullable: false),
                        Glitch = c.Boolean(nullable: false),
                        Cool = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friend", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.Friend", "NeighborID", "dbo.Neighbor");
            DropIndex("dbo.Friend", new[] { "NeighborID" });
            DropIndex("dbo.Friend", new[] { "PlayerID" });
            DropTable("dbo.Gallery");
            DropTable("dbo.Player");
            DropTable("dbo.Neighbor");
            DropTable("dbo.Friend");
        }
    }
}
