namespace TesoroQR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalleCircuitoes", "Circuito_CircuitoID", "dbo.Circuitoes");
            DropForeignKey("dbo.DetalleCircuitoes", "Pistas_PistaID", "dbo.Pistas");
            DropIndex("dbo.DetalleCircuitoes", new[] { "Circuito_CircuitoID" });
            DropIndex("dbo.DetalleCircuitoes", new[] { "Pistas_PistaID" });
            AddColumn("dbo.Pistas", "orden", c => c.Int(nullable: false));
            AddColumn("dbo.Pistas", "Circuito_CircuitoID", c => c.Int());
            CreateIndex("dbo.Pistas", "Circuito_CircuitoID");
            AddForeignKey("dbo.Pistas", "Circuito_CircuitoID", "dbo.Circuitoes", "CircuitoID");
            DropTable("dbo.DetalleCircuitoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DetalleCircuitoes",
                c => new
                    {
                        DetalleCircuitoID = c.Int(nullable: false, identity: true),
                        Orden = c.Int(nullable: false),
                        Circuito_CircuitoID = c.Int(),
                        Pistas_PistaID = c.Int(),
                    })
                .PrimaryKey(t => t.DetalleCircuitoID);
            
            DropForeignKey("dbo.Pistas", "Circuito_CircuitoID", "dbo.Circuitoes");
            DropIndex("dbo.Pistas", new[] { "Circuito_CircuitoID" });
            DropColumn("dbo.Pistas", "Circuito_CircuitoID");
            DropColumn("dbo.Pistas", "orden");
            CreateIndex("dbo.DetalleCircuitoes", "Pistas_PistaID");
            CreateIndex("dbo.DetalleCircuitoes", "Circuito_CircuitoID");
            AddForeignKey("dbo.DetalleCircuitoes", "Pistas_PistaID", "dbo.Pistas", "PistaID");
            AddForeignKey("dbo.DetalleCircuitoes", "Circuito_CircuitoID", "dbo.Circuitoes", "CircuitoID");
        }
    }
}
