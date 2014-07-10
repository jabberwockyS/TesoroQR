namespace TesoroQR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Circuitoes", "Circuito_CircuitoID", "dbo.Circuitoes");
            DropIndex("dbo.Circuitoes", new[] { "Circuito_CircuitoID" });
            DropColumn("dbo.Circuitoes", "Circuito_CircuitoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Circuitoes", "Circuito_CircuitoID", c => c.Int());
            CreateIndex("dbo.Circuitoes", "Circuito_CircuitoID");
            AddForeignKey("dbo.Circuitoes", "Circuito_CircuitoID", "dbo.Circuitoes", "CircuitoID");
        }
    }
}
