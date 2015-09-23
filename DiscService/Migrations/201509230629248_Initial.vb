Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Initial
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Discs",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Title = c.String(),
                        .Genre = c.String(),
                        .Year = c.Int(nullable := False),
                        .Price = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .SingerId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Singers", Function(t) t.SingerId, cascadeDelete := True) _
                .Index(Function(t) t.SingerId)
            
            CreateTable(
                "dbo.Singers",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Discs", "SingerId", "dbo.Singers")
            DropIndex("dbo.Discs", New String() { "SingerId" })
            DropTable("dbo.Singers")
            DropTable("dbo.Discs")
        End Sub
    End Class
End Namespace
