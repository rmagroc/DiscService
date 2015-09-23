Imports System.ComponentModel.DataAnnotations

Public Class Singer

    Public Property Id As Integer
    <Required(ErrorMessage:="Campo 'Nombre' obligatorio")> _
    Public Property Nombre As String

End Class
