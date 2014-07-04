namespace TesoroQR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Avances",
                c => new
                    {
                        AvanceID = c.Int(nullable: false, identity: true),
                        UltimaPista = c.Int(nullable: false),
                        Circuito_CircuitoID = c.Int(),
                        Juego_JuegoID = c.Int(),
                    })
                .PrimaryKey(t => t.AvanceID)
                .ForeignKey("dbo.Circuitoes", t => t.Circuito_CircuitoID)
                .ForeignKey("dbo.Juegoes", t => t.Juego_JuegoID)
                .Index(t => t.Circuito_CircuitoID)
                .Index(t => t.Juego_JuegoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Avances", "Juego_JuegoID", "dbo.Juegoes");
            DropForeignKey("dbo.Avances", "Circuito_CircuitoID", "dbo.Circuitoes");
            DropIndex("dbo.Avances", new[] { "Juego_JuegoID" });
            DropIndex("dbo.Avances", new[] { "Circuito_CircuitoID" });
            DropTable("dbo.Avances");
        }
    }
}
