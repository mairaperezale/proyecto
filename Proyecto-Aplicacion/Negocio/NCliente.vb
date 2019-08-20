Imports Entidad
Imports Datos
Public Class NCliente

    Dim objCliente As DCliente = New DCliente

    Function getCliente() As List(Of ECliente)

        Return objCliente.getAll

    End Function

    Function guardarCliente(ByVal cliente As ECliente) As Boolean

        Return objCliente.agregar(cliente)

    End Function

    Function getClienteTodos() As DataTable

        Return objCliente.getPorPorYPro

    End Function

    Function getClienteDNI(ByVal dni As Integer) As DataTable

        Return objCliente.getPorDNI(dni)

    End Function

    Function getClientePorApellido(ByVal apellido As String) As DataTable

        Return objCliente.getPorApellido(apellido)

    End Function

    Function getClienteVerificarDNI(ByVal dni As Integer) As Boolean

        Return objCliente.getverificarDni(dni)

    End Function


    Function ActualizarCliente(ByVal cliente As ECliente) As Boolean

        Return objCliente.ActualizarCli(cliente)

    End Function

    Function borrarCliente(ByVal dni As Integer) As Boolean

        Return objCliente.delCliente(dni, 0)

    End Function


    Function getBuscarCliente() As DataTable

        Return objCliente.getBuscar()

    End Function
End Class
