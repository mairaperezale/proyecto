Imports Entidad
Imports Datos
Public Class NEmpleado
    Dim objEmpleado As DEmpleado = New DEmpleado

    Function getEmpleado() As List(Of EEmpleado)

        Return objEmpleado.getAll

    End Function

    Function guardarEmpleado(ByVal empleado As EEmpleado) As Boolean

        Return objEmpleado.agregar(empleado)

    End Function

    Function getEmpleadoDNI(ByVal dni As Integer) As List(Of EEmpleado)

        Return objEmpleado.getPorDNI(dni)

    End Function

    Function getusuarioDni(ByVal dni As Integer) As List(Of EEmpleado)

        Return objEmpleado.getUsuDni(dni)

    End Function

    Function getEmpleadoPorApellido(ByVal apellido As String) As List(Of EEmpleado)

        Return objEmpleado.getPorApellido(apellido)

    End Function

    Function getusuarioPorApellido(ByVal apellido As String) As List(Of EEmpleado)

        Return objEmpleado.getUsuApellido(apellido)

    End Function

    Function getEmpleadoVerificarDNI(ByVal dni As Integer) As Boolean

        Return objEmpleado.getverificarDni(dni)

    End Function


    Function ActualizarEmpleado(ByVal empleado As EEmpleado) As Boolean

        Return objEmpleado.ActualizarEmp(empleado)

    End Function

    Function borrarEmpleado(ByVal dni As Integer) As Boolean

        Return objEmpleado.delEmpleado(dni, 0)

    End Function

   

    Function getBuscarEmpleado() As DataTable

        Return objEmpleado.getBuscar()

    End Function


    Function ActualizarUsuario(ByVal dni As Integer, ByVal usuario As String, ByVal contraseña As String, ByVal rol As String) As Boolean

        Return objEmpleado.ActualizarUsu(dni, usuario, contraseña, rol)

    End Function

    Function USU(ByVal usuario As String, ByVal contraseña As String) As DataTable

        Return objEmpleado.getUsuario(usuario, contraseña)

    End Function
End Class
