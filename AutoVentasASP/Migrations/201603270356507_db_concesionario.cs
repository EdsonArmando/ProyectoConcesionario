namespace AutoVentasASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_concesionario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archivoes",
                c => new
                    {
                        idArchivo = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        contentType = c.String(),
                        tipo = c.Int(nullable: false),
                        contenido = c.Binary(),
                        idAutomovil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idArchivo)
                .ForeignKey("dbo.Automovils", t => t.idAutomovil, cascadeDelete: true)
                .Index(t => t.idAutomovil);
            
            CreateTable(
                "dbo.Automovils",
                c => new
                    {
                        idAutomovil = c.Int(nullable: false, identity: true),
                        marca = c.String(nullable: false),
                        modelo = c.String(nullable: false),
                        color = c.String(nullable: false),
                        precio = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.idAutomovil);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        idCompra = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        idUsuario = c.Int(nullable: false),
                        idAutomovil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCompra)
                .ForeignKey("dbo.Automovils", t => t.idAutomovil, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idAutomovil);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        direccion = c.String(nullable: false),
                        nick = c.String(nullable: false),
                        contraseña = c.String(nullable: false),
                        compararContraseña = c.String(nullable: false),
                        idRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idUsuario)
                .ForeignKey("dbo.Rols", t => t.idRol, cascadeDelete: true)
                .Index(t => t.idRol);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        idRol = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idRol);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        idVenta = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        idUsuario = c.Int(nullable: false),
                        idAutomovil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idVenta)
                .ForeignKey("dbo.Automovils", t => t.idAutomovil, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idAutomovil);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Ventas", "idAutomovil", "dbo.Automovils");
            DropForeignKey("dbo.Compras", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "idRol", "dbo.Rols");
            DropForeignKey("dbo.Compras", "idAutomovil", "dbo.Automovils");
            DropForeignKey("dbo.Archivoes", "idAutomovil", "dbo.Automovils");
            DropIndex("dbo.Ventas", new[] { "idAutomovil" });
            DropIndex("dbo.Ventas", new[] { "idUsuario" });
            DropIndex("dbo.Usuarios", new[] { "idRol" });
            DropIndex("dbo.Compras", new[] { "idAutomovil" });
            DropIndex("dbo.Compras", new[] { "idUsuario" });
            DropIndex("dbo.Archivoes", new[] { "idAutomovil" });
            DropTable("dbo.Ventas");
            DropTable("dbo.Rols");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Compras");
            DropTable("dbo.Automovils");
            DropTable("dbo.Archivoes");
        }
    }
}
