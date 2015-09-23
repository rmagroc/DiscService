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

Namespace Controllers
    Public Class SingersController
        Inherits System.Web.Http.ApiController

        Private db As New DiscServiceContext

        ' GET: api/Singers
        Function GetSingers() As IQueryable(Of Singer)
            Return db.Singers
        End Function

        ' GET: api/Singers/5
        <ResponseType(GetType(Singer))>
        Async Function GetSinger(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim singer As Singer = Await db.Singers.FindAsync(id)
            If IsNothing(singer) Then
                Return NotFound()
            End If

            Return Ok(singer)
        End Function

        ' PUT: api/Singers/5
        <ResponseType(GetType(Void))>
        Async Function PutSinger(ByVal id As Integer, ByVal singer As Singer) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = singer.Id Then
                Return BadRequest()
            End If

            db.Entry(singer).State = EntityState.Modified

            Try
                Await db.SaveChangesAsync()
            Catch ex As DbUpdateConcurrencyException
                If Not (SingerExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Singers
        <ResponseType(GetType(Singer))>
        Async Function PostSinger(ByVal singer As Singer) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Singers.Add(singer)
            Await db.SaveChangesAsync()

            Return CreatedAtRoute("DefaultApi", New With {.id = singer.Id}, singer)
        End Function

        ' DELETE: api/Singers/5
        <ResponseType(GetType(Singer))>
        Async Function DeleteSinger(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim singer As Singer = Await db.Singers.FindAsync(id)
            If IsNothing(singer) Then
                Return NotFound()
            End If

            db.Singers.Remove(singer)
            Await db.SaveChangesAsync()

            Return Ok(singer)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function SingerExists(ByVal id As Integer) As Boolean
            Return db.Singers.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace