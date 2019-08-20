Imports Entidad
Imports Datos
Public Class NProducto

    Dim objProducto As DProducto = New DProducto

    Function getProducto() As List(Of EProductovb)

        Return objProducto.getAll

    End Function

    Function guardarProducto(ByVal producto As EProductovb) As Boolean

        Return objProducto.agregar(producto)

    End Function

    Function getProductoTodos() As DataTable

        Return objProducto.getPorPorYMar

    End Function

    Function getProductoId(ByVal id As Integer) As DataTable

        Return objProducto.getPorID(id)

    End Function

    Function getProductoDescripcion(ByVal descripcion As String) As DataTable

        Return objProducto.getPorDescripcion(descripcion)

    End Function

    Function getProductoVerificar(ByVal codigo As Integer) As Boolean

        Return objProducto.getverificar(codigo)

    End Function

    Function borrarProducto(ByVal codigo As Integer) As Boolean

        Return objProducto.delProducto(codigo, 0)

    End Function
    Function ActualizarProducto(ByVal producto As EProductovb) As Boolean

        Return objProducto.ActualizarPro(producto)

    End Function

    Function getBuscarProducto() As DataTable

        Return objProducto.getBuscar()

    End Function
   
End Class
