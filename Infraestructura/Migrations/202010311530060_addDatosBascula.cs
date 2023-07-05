namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDatosBascula : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Configuracion", name: "DepositoId", newName: "DepositoStockId");
            RenameIndex(table: "dbo.Configuracion", name: "IX_DepositoId", newName: "IX_DepositoStockId");
            AddColumn("dbo.Configuracion", "DepositoVentaId", c => c.Long(nullable: false));
            AddColumn("dbo.Configuracion", "ActivarBascula", c => c.Boolean(nullable: false));
            AddColumn("dbo.Configuracion", "CodigoBascula", c => c.String(nullable: false, maxLength: 4, unicode: false));
            AddColumn("dbo.Configuracion", "EsImpresionPorPrecio", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Configuracion", "DepositoVentaId");
            AddForeignKey("dbo.Configuracion", "DepositoVentaId", "dbo.Deposito", "Id");
            AddForeignKey("dbo.Configuracion", "DepositoStockId", "dbo.Deposito", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Configuracion", "DepositoStockId", "dbo.Deposito");
            DropForeignKey("dbo.Configuracion", "DepositoVentaId", "dbo.Deposito");
            DropIndex("dbo.Configuracion", new[] { "DepositoVentaId" });
            DropColumn("dbo.Configuracion", "EsImpresionPorPrecio");
            DropColumn("dbo.Configuracion", "CodigoBascula");
            DropColumn("dbo.Configuracion", "ActivarBascula");
            DropColumn("dbo.Configuracion", "DepositoVentaId");
            RenameIndex(table: "dbo.Configuracion", name: "IX_DepositoStockId", newName: "IX_DepositoId");
            RenameColumn(table: "dbo.Configuracion", name: "DepositoStockId", newName: "DepositoId");
        }
    }
}
