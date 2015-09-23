Imports System.ComponentModel.DataAnnotations

Namespace DiscService.Models

    Public Class DiscDTO

        Public Property Id As Integer
        <Required(ErrorMessage:="Campo Title obligatorio")> _
        Public Property Title As String = String.Empty
        Public Property SingerName As String = String.Empty

    End Class

End Namespace

