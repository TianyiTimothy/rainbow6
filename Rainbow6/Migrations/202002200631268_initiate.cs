namespace Rainbow6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Operators",
                c => new
                    {
                        OperatorID = c.Int(nullable: false, identity: true),
                        Alias = c.String(),
                        Name = c.String(),
                        BirthYear = c.Int(nullable: false),
                        BirthMonth = c.Int(nullable: false),
                        BirthDay = c.Int(nullable: false),
                        BirthPlace = c.String(),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Biography = c.String(),
                        UniqueAbility = c.String(),
                        UniqueAbilityDescription = c.String(),
                        UniqueAbilityImageUrl = c.String(),
                        BackgroundImageUrl = c.String(),
                        LogoImageUrl = c.String(),
                        ImageUrl = c.String(),
                        EliteImageUrl = c.String(),
                        OrganizationID = c.Int(nullable: false),
                        PositionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OperatorID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.OrganizationID)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationID = c.Int(nullable: false, identity: true),
                        ShortName = c.String(),
                        Name = c.String(),
                        IngameDescription = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.OrganizationID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.PositionID);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        WeaponID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        IngameDescription = c.String(),
                        Description = c.String(),
                        FireMode = c.String(),
                        BackgroundImageUrl = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.WeaponID);
            
            CreateTable(
                "dbo.WeaponOperators",
                c => new
                    {
                        Weapon_WeaponID = c.Int(nullable: false),
                        Operator_OperatorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Weapon_WeaponID, t.Operator_OperatorID })
                .ForeignKey("dbo.Weapons", t => t.Weapon_WeaponID, cascadeDelete: true)
                .ForeignKey("dbo.Operators", t => t.Operator_OperatorID, cascadeDelete: true)
                .Index(t => t.Weapon_WeaponID)
                .Index(t => t.Operator_OperatorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeaponOperators", "Operator_OperatorID", "dbo.Operators");
            DropForeignKey("dbo.WeaponOperators", "Weapon_WeaponID", "dbo.Weapons");
            DropForeignKey("dbo.Operators", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Operators", "OrganizationID", "dbo.Organizations");
            DropIndex("dbo.WeaponOperators", new[] { "Operator_OperatorID" });
            DropIndex("dbo.WeaponOperators", new[] { "Weapon_WeaponID" });
            DropIndex("dbo.Operators", new[] { "PositionID" });
            DropIndex("dbo.Operators", new[] { "OrganizationID" });
            DropTable("dbo.WeaponOperators");
            DropTable("dbo.Weapons");
            DropTable("dbo.Positions");
            DropTable("dbo.Organizations");
            DropTable("dbo.Operators");
        }
    }
}
