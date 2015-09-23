Imports System.ComponentModel.DataAnnotations

Public Class Disc

    Public Property Id As Integer
    <Required(ErrorMessage:="Campo Title obligatorio")> _
    Public Property Title As String
    Public Property Genre As String
    Public Property Year As Integer
    Public Property Price As Decimal

    Public Property SingerId As Integer
    Public Property Singer As Singer

End Class
