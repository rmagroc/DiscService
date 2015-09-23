Imports System.ComponentModel.DataAnnotations

Namespace DiscService.Models

    Public Class DiscDetailDTO

        Public Property Id As Integer
        <Required(ErrorMessage:="Campo Title obligatorio")> _
        Public Property Title As String = String.Empty
        Public Property Genre As String = String.Empty
        Public Property Year As Integer = Now.Year
        Public Property Price As Decimal = 0.0
        Public Property SingerName As String = String.Empty

    End Class

End Namespace
