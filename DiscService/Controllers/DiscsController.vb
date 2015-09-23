Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Web.Http
Imports System.Web.Http.Description
Imports DiscService
Imports DiscService.Models
Imports DiscService.DiscService.Models

Namespace Controllers
    Public Class DiscsController
        Inherits System.Web.Http.ApiController

        Private db As New DiscServiceContext

        ' GET: api/Discs
        Function GetDiscs() As IQueryable(Of DiscDTO)

            Dim discs = From d In db.Discs Select New DiscDTO() With {.Id = d.Id,
                                                                      .Title = d.Title,
                                                                      .SingerName = d.Singer.Nombre}

            Return discs

        End Function

        ' GET: api/Discs/5
        <ResponseType(GetType(Disc))>
        Async Function GetDisc(ByVal id As Integer) As Task(Of IHttpActionResult)

            Dim disc = Await db.Discs.Include( _
                    Function(d) d.Singer).Select _
                        ( _
                        Function(d) _
                            New DiscDetailDTO() With {.Id = d.Id,
                                                      .Title = d.Title,
                                                      .Year = d.Year,
                                                      .Price = d.Price,
                                                      .SingerName = d.Singer.Nombre,
                                                      .Genre = d.Genre}
                            ).SingleOrDefaultAsync(Function(d) d.Id = id)

            If disc Is Nothing Then
                Return NotFound()
            End If

            Return Ok(disc)

        End Function

        ' PUT: api/Discs/5
        <ResponseType(GetType(Void))>
        Async Function PutDisc(ByVal id As Integer, ByVal disc As Disc) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = disc.Id Then
                Return BadRequest()
            End If

            db.Entry(disc).State = EntityState.Modified

            Try
                Await db.SaveChangesAsync()
            Catch ex As DbUpdateConcurrencyException
                If Not (DiscExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Discs
        <ResponseType(GetType(Disc))>
        Async Function PostDisc(ByVal disc As Disc) As Task(Of IHttpActionResult)

            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Discs.Add(disc)
            Await db.SaveChangesAsync

            db.Entry(disc).Reference(Function(x) x.Singer).Load()

            Dim dto = New DiscDTO() With {.Id = disc.Id,
                                          .Title = disc.Title,
                                          .SingerName = disc.Singer.Nombre}

            Return CreatedAtRoute("DefaultApi", New With {.id = disc.Id}, dto)

        End Function

        ' DELETE: api/Discs/5
        <ResponseType(GetType(Disc))>
        Async Function DeleteDisc(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim disc As Disc = Await db.Discs.FindAsync(id)
            If IsNothing(disc) Then
                Return NotFound()
            End If

            db.Discs.Remove(disc)
            Await db.SaveChangesAsync()

            Return Ok(disc)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function DiscExists(ByVal id As Integer) As Boolean
            Return db.Discs.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace