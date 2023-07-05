namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPuestoTrabajo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PuestoTrabajo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descripcion = c.String(maxLength: 8000, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Comprobante_Factura", "PuestoTrabajoId", c => c.Long(nullable: false));
            CreateIndex("dbo.Comprobante_Factura", "PuestoTrabajoId");
            AddForeignKey("dbo.Comprobante_Factura", "PuestoTrabajoId", "dbo.PuestoTrabajo", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comprobante_Factura", "PuestoTrabajoId", "dbo.PuestoTrabajo");
            DropIndex("dbo.Comprobante_Factura", new[] { "PuestoTrabajoId" });
            DropColumn("dbo.Comprobante_Factura", "PuestoTrabajoId");
            DropTable("dbo.PuestoTrabajo");
        }
    }
}
