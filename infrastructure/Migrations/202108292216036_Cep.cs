using System;
using System.Data.Entity.Migrations;

public partial class Cep : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.CEP",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    cep = c.String(maxLength: 9, fixedLength: true, unicode: false),
                    logradouro = c.String(maxLength: 500),
                    complemento = c.String(maxLength: 500),
                    bairro = c.String(maxLength: 500),
                    localidade = c.String(maxLength: 500),
                    uf = c.String(maxLength: 2, fixedLength: true, unicode: false),
                    unidade = c.Long(nullable: false),
                    ibge = c.Int(nullable: false),
                    gia = c.String(maxLength: 500),
                })
            .PrimaryKey(t => t.Id);
        
    }
    
    public override void Down()
    {
        DropTable("dbo.CEP");
    }
}
