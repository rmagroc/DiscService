Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations

    Friend NotInheritable Class Configuration 
        Inherits DbMigrationsConfiguration(Of Models.DiscServiceContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
        End Sub

        Protected Overrides Sub Seed(context As Models.DiscServiceContext)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            '    context.People.AddOrUpdate(
            '       Function(c) c.FullName,
            '       New Customer() With {.FullName = "Andrew Peters"},
            '       New Customer() With {.FullName = "Brice Lambson"},
            '       New Customer() With {.FullName = "Rowan Miller"})

            context.Singers.AddOrUpdate(Function(c) c.Id,
                                        New Singer() With {.Id = 1, .Nombre = "Freddy Mercury"},
                                        New Singer() With {.Id = 2, .Nombre = "Miguel Ríos"},
                                        New Singer() With {.Id = 3, .Nombre = "Bunbury"}
                                        )

            context.Discs.AddOrUpdate(Function(d) d.Id,
                                       New Disc() With {.Id = 1, .Title = "Sirena Varada", .Genre = "Rock", .Year = 1998, .Price = 12.8, .SingerId = 3},
                                       New Disc() With {.Id = 2, .Title = "Made in heaven", .Genre = "Rock", .Year = 1998, .Price = 12.8, .SingerId = 1},
                                       New Disc() With {.Id = 3, .Title = "El espíritu del vino", .Genre = "Rock", .Year = 1998, .Price = 12.8, .SingerId = 3},
                                       New Disc() With {.Id = 4, .Title = "En el parque", .Genre = "Rock", .Year = 1998, .Price = 12.8, .SingerId = 2}
                                      )


        End Sub

    End Class

End Namespace
