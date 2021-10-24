﻿namespace Infraestructura.Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subtitulo = c.String(),
                        Titulo = c.String(),
                        Descripcion = c.String(),
                        PalabrasClave = c.String(),
                        UrlImagenPrincipal = c.String(),
                        UrlSlug = c.String(),
                        FechaPost = c.DateTime(nullable: false),
                        ContenidoHtml = c.String(),
                        PostContenidoHtml = c.String(),
                        EsBorrador = c.Boolean(nullable: false),
                        EsRssAtom = c.Boolean(nullable: false),
                        FechaPublicacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        Autor = c.String(),
                        TituloSinAcentos = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        UrlSlug = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Post_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPosts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagPosts", new[] { "Post_Id" });
            DropIndex("dbo.TagPosts", new[] { "Tag_Id" });
            DropTable("dbo.TagPosts");
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
        }
    }
}
