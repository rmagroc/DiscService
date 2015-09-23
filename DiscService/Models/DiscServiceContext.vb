Imports System.Data.Entity

Namespace Models
    
    Public Class DiscServiceContext
        Inherits DbContext
    
        ' You can add custom code to this file. Changes will not be overwritten.
        ' 
        ' If you want Entity Framework to drop and regenerate your database
        ' automatically whenever you change your model schema, please use data migrations.
        ' For more information refer to the documentation:
        ' http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        Public Sub New()
            MyBase.New("name=DiscServiceContext")

            Me.Database.Log = Sub(s) System.Diagnostics.Debug.WriteLine(s)

        End Sub
    
        Public Property Singers As System.Data.Entity.DbSet(Of Singer)
        Public Property Discs As System.Data.Entity.DbSet(Of Disc)

    End Class
    
End Namespace
