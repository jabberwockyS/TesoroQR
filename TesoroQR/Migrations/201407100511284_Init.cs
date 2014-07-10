namespace TesoroQR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
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
            
            CreateTable(
                "dbo.Circuitoes",
                c => new
                    {
                        CircuitoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Partida_PartidaID = c.Int(),
                    })
                .PrimaryKey(t => t.CircuitoID)
                .ForeignKey("dbo.Partidas", t => t.Partida_PartidaID)
                .Index(t => t.Partida_PartidaID);
            
            CreateTable(
                "dbo.Partidas",
                c => new
                    {
                        PartidaID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PartidaID);
            
            CreateTable(
                "dbo.Pistas",
                c => new
                    {
                        PistaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        orden = c.Int(nullable: false),
                        Circuito_CircuitoID = c.Int(),
                    })
                .PrimaryKey(t => t.PistaID)
                .ForeignKey("dbo.Circuitoes", t => t.Circuito_CircuitoID)
                .Index(t => t.Circuito_CircuitoID);
            
            CreateTable(
                "dbo.Juegoes",
                c => new
                    {
                        JuegoID = c.Int(nullable: false, identity: true),
                        HoraInicio = c.DateTime(nullable: false),
                        horaFin = c.DateTime(nullable: false),
                        Jugador_UsuarioID = c.Int(),
                        Partida_PartidaID = c.Int(),
                    })
                .PrimaryKey(t => t.JuegoID)
                .ForeignKey("dbo.Usuarios", t => t.Jugador_UsuarioID)
                .ForeignKey("dbo.Partidas", t => t.Partida_PartidaID)
                .Index(t => t.Jugador_UsuarioID)
                .Index(t => t.Partida_PartidaID);
            
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
            
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Avances", "Juego_JuegoID", "dbo.Juegoes");
            DropForeignKey("dbo.Juegoes", "Partida_PartidaID", "dbo.Partidas");
            DropForeignKey("dbo.Juegoes", "Jugador_UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Avances", "Circuito_CircuitoID", "dbo.Circuitoes");
            DropForeignKey("dbo.Pistas", "Circuito_CircuitoID", "dbo.Circuitoes");
            DropForeignKey("dbo.Circuitoes", "Partida_PartidaID", "dbo.Partidas");
            DropIndex("dbo.Avances", new[] { "Juego_JuegoID" });
            DropIndex("dbo.Juegoes", new[] { "Partida_PartidaID" });
            DropIndex("dbo.Juegoes", new[] { "Jugador_UsuarioID" });
            DropIndex("dbo.Avances", new[] { "Circuito_CircuitoID" });
            DropIndex("dbo.Pistas", new[] { "Circuito_CircuitoID" });
            DropIndex("dbo.Circuitoes", new[] { "Partida_PartidaID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Juegoes");
            DropTable("dbo.Pistas");
            DropTable("dbo.Partidas");
            DropTable("dbo.Circuitoes");
            DropTable("dbo.Avances");
            CreateIndex("dbo.AspNetUserClaims", "User_Id");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            AddForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
