namespace TesoroQR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitPrimero : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Circuitoes",
                c => new
                    {
                        CircuitoID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.CircuitoID);
            
            CreateTable(
                "dbo.DetalleCircuitoes",
                c => new
                    {
                        DetalleCircuitoID = c.Int(nullable: false, identity: true),
                        Orden = c.Int(nullable: false),
                        Circuito_CircuitoID = c.Int(),
                        Pistas_PistaID = c.Int(),
                    })
                .PrimaryKey(t => t.DetalleCircuitoID)
                .ForeignKey("dbo.Circuitoes", t => t.Circuito_CircuitoID)
                .ForeignKey("dbo.Pistas", t => t.Pistas_PistaID)
                .Index(t => t.Circuito_CircuitoID)
                .Index(t => t.Pistas_PistaID);
            
            CreateTable(
                "dbo.Pistas",
                c => new
                    {
                        PistaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.PistaID);
            
            CreateTable(
                "dbo.Juegoes",
                c => new
                    {
                        JuegoID = c.Int(nullable: false, identity: true),
                        HoraInicio = c.DateTime(nullable: false),
                        horaFin = c.DateTime(nullable: false),
                        Circuito_CircuitoID = c.Int(),
                        Juegador_UsuarioID = c.Int(),
                    })
                .PrimaryKey(t => t.JuegoID)
                .ForeignKey("dbo.Circuitoes", t => t.Circuito_CircuitoID)
                .ForeignKey("dbo.Usuarios", t => t.Juegador_UsuarioID)
                .Index(t => t.Circuito_CircuitoID)
                .Index(t => t.Juegador_UsuarioID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Contraseña = c.String(),
                        TipoUsuario = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Juegoes", "Juegador_UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Juegoes", "Circuito_CircuitoID", "dbo.Circuitoes");
            DropForeignKey("dbo.DetalleCircuitoes", "Pistas_PistaID", "dbo.Pistas");
            DropForeignKey("dbo.DetalleCircuitoes", "Circuito_CircuitoID", "dbo.Circuitoes");
            DropIndex("dbo.Juegoes", new[] { "Juegador_UsuarioID" });
            DropIndex("dbo.Juegoes", new[] { "Circuito_CircuitoID" });
            DropIndex("dbo.DetalleCircuitoes", new[] { "Pistas_PistaID" });
            DropIndex("dbo.DetalleCircuitoes", new[] { "Circuito_CircuitoID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Juegoes");
            DropTable("dbo.Pistas");
            DropTable("dbo.DetalleCircuitoes");
            DropTable("dbo.Circuitoes");
        }
    }
}
