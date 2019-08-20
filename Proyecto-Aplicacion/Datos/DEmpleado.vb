Imports Entidad
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Public Class DEmpleado
    Dim connectionString = ConfigurationManager.ConnectionStrings("conexionBD").ConnectionString

    Dim miconexion As SqlConnection = New SqlConnection(connectionString)


    Public Function getAll() As List(Of EEmpleado)

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM empleado", miconexion)

        miconexion.Open()

        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim listaEmpleado As New List(Of EEmpleado)

        Do While reader.Read()

            Dim item As EEmpleado = New EEmpleado

            item.Dni = reader("dni")
            item.Nombre = reader("nombre")
            item.Apellido = reader("apellido")
            item.Telefono = reader("telefono")
            item.Direccion = reader("direccion")
            item.Email = reader("email")
            item.FechaAlta = reader("fecha_alta")
            item.Sueldo = reader("sueldo")
            item.Estado = reader("estado")
            item.Usuario = reader("usuario")
            item.Contraseña = reader("contraseña")
            item.Rol = reader("rol")
            listaEmpleado.Add(item)
        Loop
        miconexion.Close()
        Return listaEmpleado


    End Function


    Function agregar(ByVal empleado As EEmpleado) As Boolean

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM empleado", miconexion)

        Dim insertar As String
        insertar = "INSERT INTO empleado (dni, nombre, apellido,telefono, direccion,email, fecha_alta, sueldo,estado,usuario,contraseña,rol) " & _
      "VALUES " & _
      " (@dni,@nombre,@apellido,@telefono,@direccion,@email, @fecha_alta, @sueldo,@estado,@usuario,@contraseña,@rol) "

        Dim cmdInsertar As New SqlCommand(insertar, miconexion)

        cmdInsertar.Parameters.AddWithValue("@dni", empleado.Dni)
        cmdInsertar.Parameters.AddWithValue("@nombre", empleado.Nombre)
        cmdInsertar.Parameters.AddWithValue("@apellido", empleado.Apellido)
        cmdInsertar.Parameters.AddWithValue("@telefono", empleado.Telefono)
        cmdInsertar.Parameters.AddWithValue("@direccion", empleado.Direccion)
        cmdInsertar.Parameters.AddWithValue("@email", empleado.Email)
        cmdInsertar.Parameters.AddWithValue("@fecha_alta", empleado.FechaAlta)
        cmdInsertar.Parameters.AddWithValue("@sueldo", empleado.Sueldo)
        cmdInsertar.Parameters.AddWithValue("@estado", empleado.Estado)
        cmdInsertar.Parameters.AddWithValue("@usuario", empleado.Usuario)
        cmdInsertar.Parameters.AddWithValue("@contraseña", empleado.Contraseña)
        cmdInsertar.Parameters.AddWithValue("@rol", empleado.Rol)
        Try
            miconexion.Open()
            cmdInsertar.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        Finally
            miconexion.Close()
        End Try

    End Function


    Public Function getPorDNI(ByVal dni As Integer) As List(Of EEmpleado)

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM empleado where dni = '  " & dni & " ' and estado=1 ", miconexion)

        miconexion.Open()

        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim listaEmpleado As New List(Of EEmpleado)

        Do While reader.Read()

            Dim item As EEmpleado = New EEmpleado

            item.Dni = reader("dni")
            item.Nombre = reader("nombre")
            item.Apellido = reader("apellido")
            item.Telefono = reader("telefono")
            item.Direccion = reader("direccion")
            item.Email = reader("email")
            item.FechaAlta = reader("fecha_alta")
            item.Sueldo = reader("sueldo")


            listaEmpleado.Add(item)
        Loop
        miconexion.Close()
        Return listaEmpleado


    End Function


    Public Function getUsuDni(ByVal dni As Integer) As List(Of EEmpleado)

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM empleado where dni = '  " & dni & " ' and estado=1 ", miconexion)

        miconexion.Open()

        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim listaEmpleado As New List(Of EEmpleado)

        Do While reader.Read()

            Dim item As EEmpleado = New EEmpleado

            item.Dni = reader("dni")
            item.Nombre = reader("nombre")
            item.Apellido = reader("apellido")
            item.Telefono = reader("telefono")
            item.Direccion = reader("direccion")
            item.Email = reader("email")
            item.FechaAlta = reader("fecha_alta")
            item.Sueldo = reader("sueldo")
            item.Usuario = reader("usuario")
            item.Contraseña = reader("contraseña")
            item.Rol = reader("rol")

            listaEmpleado.Add(item)
        Loop
        miconexion.Close()
        Return listaEmpleado


    End Function

    Public Function getPorApellido(ByVal apellido As String) As List(Of EEmpleado)

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM empleado WHERE apellido LIKE '%" & apellido & "%' and estado=1", miconexion)

        miconexion.Open()

        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim listaEmpleado As New List(Of EEmpleado)

        Do While reader.Read()

            Dim item As EEmpleado = New EEmpleado

            item.Dni = reader("dni")
            item.Nombre = reader("nombre")
            item.Apellido = reader("apellido")
            item.Telefono = reader("telefono")
            item.Direccion = reader("direccion")
            item.Email = reader("email")
            item.FechaAlta = reader("fecha_alta")
            item.Sueldo = reader("sueldo")

            listaEmpleado.Add(item)
        Loop
        miconexion.Close()
        Return listaEmpleado


    End Function


    Public Function getUsuApellido(ByVal apellido As String) As List(Of EEmpleado)

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM empleado WHERE apellido LIKE '%" & apellido & "%' and estado=1", miconexion)

        miconexion.Open()

        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim listaEmpleado As New List(Of EEmpleado)

        Do While reader.Read()

            Dim item As EEmpleado = New EEmpleado

            item.Dni = reader("dni")
            item.Nombre = reader("nombre")
            item.Apellido = reader("apellido")
            item.Telefono = reader("telefono")
            item.Direccion = reader("direccion")
            item.Email = reader("email")
            item.FechaAlta = reader("fecha_alta")
            item.Sueldo = reader("sueldo")
            item.Usuario = reader("usuario")
            item.Contraseña = reader("contraseña")
            item.Rol = reader("rol")
            listaEmpleado.Add(item)
        Loop
        miconexion.Close()
        Return listaEmpleado


    End Function

    Public Function getverificarDni(ByVal dni As Integer) As Boolean

        Dim Sql As String = "SELECT dni  FROM empleado where dni = '  " & dni & " '  "
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Return True

    End Function


    Function ActualizarEmp(ByVal empleado As EEmpleado) As Boolean

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM empleado", miconexion)

        Dim actualizar As String
        actualizar = "UPDATE  empleado SET dni=@dni, nombre=@nombre, apellido=@apellido,telefono=@telefono, direccion=@direccion,email=@email, fecha_alta=@fecha_alta, sueldo=@sueldo where dni=@dni"

        Dim cmdActualizar As New SqlCommand(actualizar, miconexion)

        cmdActualizar.Parameters.AddWithValue("@dni", empleado.Dni)
        cmdActualizar.Parameters.AddWithValue("@nombre", empleado.Nombre)
        cmdActualizar.Parameters.AddWithValue("@apellido", empleado.Apellido)
        cmdActualizar.Parameters.AddWithValue("@telefono", empleado.Telefono)
        cmdActualizar.Parameters.AddWithValue("@direccion", empleado.Direccion)
        cmdActualizar.Parameters.AddWithValue("@email", empleado.Email)
        cmdActualizar.Parameters.AddWithValue("@fecha_alta", empleado.FechaAlta)
        cmdActualizar.Parameters.AddWithValue("@sueldo", empleado.Sueldo)

        Try
            miconexion.Open()
            cmdActualizar.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        Finally
            miconexion.Close()
        End Try

    End Function

    Function delEmpleado(ByVal dni As Integer, ByVal estado As Integer) As Boolean

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM empleado", miconexion)

        Dim borrar As String
        borrar = "UPDATE empleado SET estado = @estado WHERE dni = @dni"

        Dim cmdActualizar As New SqlCommand(borrar, miconexion)

        cmdActualizar.Parameters.AddWithValue("@dni", dni)
        cmdActualizar.Parameters.AddWithValue("@estado", estado)

        Try
            miconexion.Open()
            cmdActualizar.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        Finally
            miconexion.Close()
        End Try

    End Function


    Function ActualizarUsu(ByVal dni As Integer, ByVal usuario As String, ByVal contraseña As String, ByVal rol As String) As Boolean

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM empleado", miconexion)

        Dim actualizar As String
        actualizar = "UPDATE  empleado SET dni=@dni,usuario=@usuario,contraseña=@contraseña,rol=@rol where dni=@Dni"

        Dim cmdActualizar As New SqlCommand(actualizar, miconexion)

        cmdActualizar.Parameters.AddWithValue("@dni", dni)
        'cmdActualizar.Parameters.AddWithValue("@nombre", empleado.Nombre)
        'cmdActualizar.Parameters.AddWithValue("@apellido", empleado.Apellido)
        'cmdActualizar.Parameters.AddWithValue("@telefono", empleado.Telefono)
        'cmdActualizar.Parameters.AddWithValue("@direccion", empleado.Direccion)
        'cmdActualizar.Parameters.AddWithValue("@email", empleado.Email)
        'cmdActualizar.Parameters.AddWithValue("@fecha_alta", empleado.FechaAlta)
        'cmdActualizar.Parameters.AddWithValue("@sueldo", empleado.Sueldo)
        'cmdActualizar.Parameters.AddWithValue("@estado", empleado.Estado)
        cmdActualizar.Parameters.AddWithValue("@usuario", usuario)
        cmdActualizar.Parameters.AddWithValue("@contraseña", contraseña)
        cmdActualizar.Parameters.AddWithValue("@rol", rol)
        'Try
        miconexion.Open()
        cmdActualizar.ExecuteNonQuery()
        'Return True
        'Catch ex As Exception
        '    Return False
        'Finally
        miconexion.Close()
        'End Try

    End Function

    Public Function getBuscar() As DataTable

        Dim Sql As String = "SELECT * FROM empleado where estado = 1  "
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Dim dt As DataTable = New DataTable()
        'da.Fill(dt)
        da.Fill(dt)
        Return dt


    End Function


    'Public Function getUsuario(ByVal usuario As String, ByVal contraseña As String) As List(Of EEmpleado)

    '    Dim command As SqlCommand = New SqlCommand("SELECT usuario,contraseña,rol FROM empleado", miconexion)

    '    miconexion.Open()

    '    Dim reader As SqlDataReader = command.ExecuteReader()

    '    Dim listaEmpleado As New List(Of EEmpleado)

    '    Do While reader.Read()

    '        Dim item As EEmpleado = New EEmpleado

    '        'item.Dni = reader("dni")
    '        'item.Nombre = reader("nombre")
    '        'item.Apellido = reader("apellido")
    '        'item.Telefono = reader("telefono")
    '        'item.Direccion = reader("direccion")
    '        'item.Email = reader("email")
    '        'item.FechaAlta = reader("fecha_alta")
    '        'item.Sueldo = reader("sueldo")
    '        'item.Estado = reader("estado")
    '        item.Usuario = reader("usuario")
    '        item.Contraseña = reader("contraseña")
    '        item.Rol = reader("rol")
    '        listaEmpleado.Add(item)
    '    Loop
    '    miconexion.Close()
    '    Return listaEmpleado


    'End Function


    Public Function getUsuario(ByVal usu As String, ByVal cont As String) As DataTable

        Dim Sql As String = "SELECT usuario,contraseña,rol FROM empleado where usuario = '" & usu & "' and contraseña='" & Cont & "'"
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Dim dt As DataTable = New DataTable()
        'da.Fill(dt)
        da.Fill(dt)
        Return dt


    End Function
End Class
