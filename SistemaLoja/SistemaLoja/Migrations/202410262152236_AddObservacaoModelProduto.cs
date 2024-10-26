namespace SistemaLoja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddObservacaoModelProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        FuncionarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comissao = c.Single(nullable: false),
                        Nascimento = c.DateTime(nullable: false),
                        Cadastro = c.DateTime(nullable: false),
                        Email = c.String(),
                        TipoDocumento_TipoDocumentoID = c.Int(),
                    })
                .PrimaryKey(t => t.FuncionarioId)
                .ForeignKey("dbo.TipoDocumentoes", t => t.TipoDocumento_TipoDocumentoID)
                .Index(t => t.TipoDocumento_TipoDocumentoID);
            
            CreateTable(
                "dbo.TipoDocumentoes",
                c => new
                    {
                        TipoDocumentoID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.TipoDocumentoID);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UltimaCompra = c.DateTime(nullable: false),
                        Estoque = c.Single(nullable: false),
                        Comentario = c.String(),
                        Observacao = c.String(),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionarios", "TipoDocumento_TipoDocumentoID", "dbo.TipoDocumentoes");
            DropIndex("dbo.Funcionarios", new[] { "TipoDocumento_TipoDocumentoID" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.TipoDocumentoes");
            DropTable("dbo.Funcionarios");
        }
    }
}
