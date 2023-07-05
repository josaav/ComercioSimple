namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacionConfig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configuracion", "DepositoId", c => c.Long(nullable: false));
            CreateIndex("dbo.Configuracion", "DepositoId");
            AddForeignKey("dbo.Configuracion", "DepositoId", "dbo.Deposito", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Configuracion", "DepositoId", "dbo.Deposito");
            DropIndex("dbo.Configuracion", new[] { "DepositoId" });
            DropColumn("dbo.Configuracion", "DepositoId");
        }
    }
}
