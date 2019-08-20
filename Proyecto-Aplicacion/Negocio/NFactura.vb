Imports Entidad
Imports Datos
Public Class NFactura

    Dim objFactura As DFactura = New DFactura

    Public Sub guardarFactura(ByVal factura As EFactura, ByVal detalle As List(Of EDetalle))
        objFactura.agregarFactura(factura)
        For Each valor As EDetalle In detalle
            objFactura.agregarDetalle(valor)
        Next
    End Sub


    Function obtenerId() As DataTable

        Return objFactura.ultimoId()

    End Function

    Function cargarfac(ByVal valor As Integer) As DataTable

        Return objFactura.cargarfactura(valor)

    End Function


    Function prbarreporte()

        Return objFactura.probar()

    End Function
End Class
