namespace TSTOneighboreenos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TSTOneighboreenos.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<TSTOneighboreenos.DAL.NeighboreenoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TSTOneighboreenos.DAL.NeighboreenoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  Adapted from tutorial
            var players = new List<Player>
            {
                new Player { ID=1, TSTOhandle = "jtsmith", Level = 21, NameFirst = "John", NameLast = "Smith", 
                    MidInit = "T", Email = "jtsmith@test.com", 
                    SpringfieldPath = "~/Content/Images/springfields/tsto_homeScreen-tmb.png", 
                    Active = true, AddMe = true },
                new Player { ID=2, TSTOhandle = "BillyBoy428", Level = 30, NameFirst = "Bill", NameLast = "Johnson",
                    MidInit = "M", Email = "BillyBoy428@test.com",
                    SpringfieldPath = "~/Content/Images/springfields/tsto_homeScreen-tmb.png",
                    Active = true, AddMe = true },
                new Player { ID=3, TSTOhandle="LisaIsGr8", Level = 09, NameFirst = "Lisa", NameLast = "Kinderson",
                    MidInit = "A", Email = "LisaIsGr8@test.com",
                    SpringfieldPath = "~/Content/Images/springfields/tsto_homeScreen-tmb.png",
                    Active = true, AddMe = true },
                new Player { ID=4, TSTOhandle = "fhonda", Level = 42, NameFirst = "Frank", NameLast = "Honda",
                    MidInit = "N", Email = "fhonda@test.com",
                    SpringfieldPath = "~/Content/Images/springfields/tsto_homeScreen-tmb.png",
                    Active = true, AddMe = true },
                new Player { ID=5, TSTOhandle = "NatShell", Level = 48, NameFirst = "Natalie", NameLast = "Shelly",
                    MidInit = "B", Email = "NatShell@test.com",
                    SpringfieldPath = "~/Content/Images/springfields/tsto_homeScreen-tmb.png",
                    Active = true, AddMe = true }
            };
            players.ForEach(s => context.Players.AddOrUpdate(p => p.TSTOhandle, s));  // 'p' is for 'property', one that is unique to this row of data (and the rest of the database)
            context.SaveChanges();

            var neighbors = new List<Neighbor>
            {
                new Neighbor { ID=1, TSTOhandle = "BillyBoy428", Level = 30,
                    SpringfieldPath = "~/Content/Images/springfields/tsto_homeScreen-tmb.png",
                    Active=true },
                new Neighbor { ID=2, TSTOhandle = "LisaIsGr8", Level = 09,
                    SpringfieldPath = "~/Content/Images/springfields/tsto_homeScreen-tmb.png",
                    Active=true },
                new Neighbor { ID=3, TSTOhandle = "jtsmith", Level = 21,
                    SpringfieldPath = "~/Content/Images/springfields/tsto_homeScreen-tmb.png",
                    Active = true },
                new Neighbor { ID=4, TSTOhandle = "fhonda", Level = 42,
                    SpringfieldPath = "~/Content/Images/springfields/tsto_homeScreen-tmb.png",
                    Active = true },
                new Neighbor { ID=5, TSTOhandle = "NatShell", Level = 48,
                    SpringfieldPath = "~/Content/Images/springfields/tsto_homeScreen-tmb.png", 
                    Active = true }
            };
            neighbors.ForEach(n => context.Neighbors.AddOrUpdate(p => p.TSTOhandle, n));
            context.SaveChanges();

            var friends = new List<Friend>
            {
                new Friend { ID=1, PlayerID=1, NeighborID=2 },
                new Friend { ID=2, PlayerID=1, NeighborID=3 },
                new Friend { ID=3, PlayerID=1, NeighborID=4 },
                new Friend { ID=4, PlayerID=2, NeighborID=1 },
                new Friend { ID=5, PlayerID=2, NeighborID=4 },
                new Friend { ID=6, PlayerID=3, NeighborID=1 },
                new Friend { ID=7, PlayerID=3, NeighborID=2 },
                new Friend { ID=8, PlayerID=3, NeighborID=4 },
                new Friend { ID=9, PlayerID=4, NeighborID=1 }
            };
            // not sure if this is correct. Should it be handled differently?
            friends.ForEach(f => context.Friends.AddOrUpdate(p => p.ID, f));
            context.SaveChanges(); /* */

            var galleries = new List<Gallery>
            {
                new Gallery { ID=1, ImgPath = "~/Content/Images/gallery/abandoned/thumb/AbandonedSF_dylanchallen-tmb.png",
                    Title = "dylanchallen", Desc = "Very lovely Springfield. Hasn't been active for over six months.",
                    Abandon = true },
                new Gallery { ID=2, ImgPath = "~/Content/Images/gallery/abandoned/thumb/AbandonedSF_EVILNOCTURNE-tmb.png",
                    Title = "EVILNOCTURNE", Desc = "Very lovely Springfield. Hasn't been active for over six months.",
                    Abandon = true },
                new Gallery { ID=3, ImgPath = "~/Content/Images/gallery/abandoned/thumb/AbandonedSF_hulkavitch-tmb.png",
                    Title = "hulkavitch", Desc = "Very lovely Springfield. Hasn't been active for over six months.",
                    Abandon=true },
                new Gallery { ID=4, ImgPath = "~/Content/Images/gallery/abandoned/thumb/AbandonedSF_MinedTiger7-tmb.png",
                    Title = "MinedTiger7", Desc = "Very lovely Springfield. Hasn't been active for over six months.",
                    Abandon = true },
                new Gallery { ID=5, ImgPath = "~/Content/Images/gallery/abandoned/thumb/AbandonedSF_dylanchallen-tmb.png",
                    Title = "dylanchallen", Desc = "Very lovely Springfield. Hasn't been active for over six months.",
                    Abandon = true },
                new Gallery { ID=100, ImgPath = "~/Content/Images/gallery/coolshots/thumb/CoolShots_EVILNOCTURNE-Aztec01-tmb.png",
                    Title="EVILNOCTURNE's Aztec Theater", Desc = "EVILNOCTURNE's layout for the Aztec Theater is pretty nice.",
                    Cool = true },
                new Gallery { ID=101, ImgPath = "~/Content/Images/gallery/coolshots/thumb/CoolShots_EVILNOCTURNE-Aztec02-tmb.png",
                    Title = "EVILNOCTURNE's Aztec Theater 2", Desc = "Another view of the layout for the Aztec Theater.",
                    Cool = true },
                new Gallery { ID=102, ImgPath = "~/Content/Images/gallery/coolshots/thumb/CoolShots_EVILNOCTURNE-CletusFarm-tmb.png",
                    Title = "EVILNOCTURNE's Cletus' Farm", Desc = "",
                    Cool = true },
                new Gallery { ID=103, ImgPath = "~/Content/Images/gallery/coolshots/thumb/CoolShots_MindedTiger7-lemonTree-tmb.png",
                    Title = "MindedTiger7's Lemon Tree", Desc = "",
                    Cool = true },
                new Gallery { ID=104, ImgPath = "~/Content/Images/gallery/coolshots/thumb/CoolShots_wutpain-driveIn01-tmb.png",
                    Title = "wutpain's Drive-In", Desc = "",
                    Cool = true },
                new Gallery { ID=105, ImgPath = "~/Content/Images/gallery/coolshots/thumb/CoolShots_wutpain-drivein02-tmb.png",
                    Title = "wutpain's Drive-In 2", Desc = "",
                    Cool = true },
                new Gallery { ID=106, ImgPath = "~/Content/Images/gallery/coolshots/thumb/CoolShots_EVILNOCTURNE-Aztec01-tmb.png",
                    Title = "EVILNOCTURNE's Aztec Theater 3", Desc = "",
                    Cool = true }
            };
            galleries.ForEach(g => context.Galleries.AddOrUpdate(p => p.ID, g));
            context.SaveChanges();
        }
    }
}
