Imports Datos
Imports Entidad
Public Class NProvincia

    Dim objProvincia = New DProvincia

    Function getProvincia() As List(Of EProvincia)

        Return objProvincia.getAll

    End Function

End Class
