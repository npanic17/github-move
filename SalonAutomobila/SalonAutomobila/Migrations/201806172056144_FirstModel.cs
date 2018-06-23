namespace SalonAutomobila.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 70),
                        Year = c.Int(nullable: false),
                        EngineVolume = c.Int(nullable: false),
                        Color = c.String(nullable: false, maxLength: 70),
                        ManufacturerId = c.Int(nullable: false),
                        CarSalonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salon", t => t.CarSalonId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId)
                .Index(t => t.CarSalonId);
            
            CreateTable(
                "dbo.Salon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PIB = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 70),
                        Country = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 70),
                        Address = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contract",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractName = c.String(name: "Contract Name", nullable: false, maxLength: 70),
                        CarSalonId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salon", t => t.CarSalonId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.CarSalonId)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                        Country = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contract", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Car", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Contract", "CarSalonId", "dbo.Salon");
            DropForeignKey("dbo.Car", "CarSalonId", "dbo.Salon");
            DropIndex("dbo.Contract", new[] { "ManufacturerId" });
            DropIndex("dbo.Contract", new[] { "CarSalonId" });
            DropIndex("dbo.Car", new[] { "CarSalonId" });
            DropIndex("dbo.Car", new[] { "ManufacturerId" });
            DropTable("dbo.Manufacturer");
            DropTable("dbo.Contract");
            DropTable("dbo.Salon");
            DropTable("dbo.Car");
        }
    }
}
