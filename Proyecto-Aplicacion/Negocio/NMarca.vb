Imports Datos
Imports Entidad
Public Class NMarca

    Dim objMarca = New DMarca

    Function getMarca() As List(Of EMarca)

        Return objMarca.getAll

    End Function
End Class
