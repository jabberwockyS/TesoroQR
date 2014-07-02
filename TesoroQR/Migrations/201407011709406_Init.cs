namespace TesoroQR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Juegoes", "Circuito_CircuitoID", "dbo.Circuitoes");
            DropForeignKey("dbo.Juegoes", "Juegador_UsuarioID", "dbo.Usuarios");
            DropIndex("dbo.Juegoes", new[] { "Circuito_CircuitoID" });
            DropIndex("dbo.Juegoes", new[] { "Juegador_UsuarioID" });
            CreateTable(
                "dbo.Partidas",
                c => new
                    {
                        PartidaID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PartidaID);
            
            AddColumn("dbo.Circuitoes", "Partida_PartidaID", c => c.Int());
            AddColumn("dbo.Juegoes", "Jugador_UsuarioID", c => c.Int());
            AddColumn("dbo.Juegoes", "Partida_PartidaID", c => c.Int());
            CreateIndex("dbo.Circuitoes", "Partida_PartidaID");
            CreateIndex("dbo.Juegoes", "Jugador_UsuarioID");
            CreateIndex("dbo.Juegoes", "Partida_PartidaID");
            AddForeignKey("dbo.Circuitoes", "Partida_PartidaID", "dbo.Partidas", "PartidaID");
            AddForeignKey("dbo.Juegoes", "Jugador_UsuarioID", "dbo.Usuarios", "UsuarioID");
            AddForeignKey("dbo.Juegoes", "Partida_PartidaID", "dbo.Partidas", "PartidaID");
            DropColumn("dbo.Circuitoes", "Fecha");
            DropColumn("dbo.Circuitoes", "Descripcion");
            DropColumn("dbo.Juegoes", "Circuito_CircuitoID");
            DropColumn("dbo.Juegoes", "Juegador_UsuarioID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Juegoes", "Juegador_UsuarioID", c => c.Int());
            AddColumn("dbo.Juegoes", "Circuito_CircuitoID", c => c.Int());
            AddColumn("dbo.Circuitoes", "Descripcion", c => c.String());
            AddColumn("dbo.Circuitoes", "Fecha", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Juegoes", "Partida_PartidaID", "dbo.Partidas");
            DropForeignKey("dbo.Juegoes", "Jugador_UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Circuitoes", "Partida_PartidaID", "dbo.Partidas");
            DropIndex("dbo.Juegoes", new[] { "Partida_PartidaID" });
            DropIndex("dbo.Juegoes", new[] { "Jugador_UsuarioID" });
            DropIndex("dbo.Circuitoes", new[] { "Partida_PartidaID" });
            DropColumn("dbo.Juegoes", "Partida_PartidaID");
            DropColumn("dbo.Juegoes", "Jugador_UsuarioID");
            DropColumn("dbo.Circuitoes", "Partida_PartidaID");
            DropTable("dbo.Partidas");
            CreateIndex("dbo.Juegoes", "Juegador_UsuarioID");
            CreateIndex("dbo.Juegoes", "Circuito_CircuitoID");
            AddForeignKey("dbo.Juegoes", "Juegador_UsuarioID", "dbo.Usuarios", "UsuarioID");
            AddForeignKey("dbo.Juegoes", "Circuito_CircuitoID", "dbo.Circuitoes", "CircuitoID");
        }
    }
}
