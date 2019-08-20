Imports Entidad
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class DCliente


    Dim connectionString = ConfigurationManager.ConnectionStrings("conexionBD").ConnectionString

    Dim miconexion As SqlConnection = New SqlConnection(connectionString)


    Public Function getAll() As List(Of ECliente)

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM cliente", miconexion)

        miconexion.Open()

        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim listaCliente As New List(Of ECliente)

        Do While reader.Read()

            Dim item As ECliente = New ECliente

            item.Dni = reader("dni")
            item.Nombre = reader("nombre")
            item.Apellido = reader("apellido")
            item.Telefono = reader("telefono")
            item.Direccion = reader("direccion")
            item.Email = reader("email")
            item.Provincia = reader("provincia_id")
            item.Estado = reader("estado")
            listaCliente.Add(item)
        Loop
        miconexion.Close()
        Return listaCliente


    End Function


    Function agregar(ByVal cliente As ECliente) As Boolean

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM cliente", miconexion)
        
        Dim insertar As String
        insertar = "INSERT INTO  cliente(dni, nombre, apellido,telefono, direccion,email, provincia_id,estado) " & _
      "VALUES " & _
      " (@dni,@nombre,@apellido,@telefono,@direccion,@email, @provincia,@estado) "

        Dim cmdInsertar As New SqlCommand(insertar, miconexion)

        cmdInsertar.Parameters.AddWithValue("@dni", cliente.Dni)
        cmdInsertar.Parameters.AddWithValue("@nombre", cliente.Nombre)
        cmdInsertar.Parameters.AddWithValue("@apellido", cliente.Apellido)
        cmdInsertar.Parameters.AddWithValue("@telefono", cliente.Telefono)
        cmdInsertar.Parameters.AddWithValue("@direccion", cliente.Direccion)
        cmdInsertar.Parameters.AddWithValue("@email", cliente.Email)
        cmdInsertar.Parameters.AddWithValue("@provincia", cliente.Provincia)
        cmdInsertar.Parameters.AddWithValue("@estado", cliente.Estado)
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

    Public Function getPorPorYPro() As DataTable

        Dim Sql As String = "SELECT C.Dni, C.Nombre, C.Apellido, C.Telefono, C.Direccion, C.Email, P.Descripcion_Provincia,C.Estado FROM cliente C INNER JOIN provincia  P ON C.provincia_id = P.id_provincia"
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Dim dt As DataTable = New DataTable()
        'da.Fill(dt)
        da.Fill(dt)
        Return dt

    End Function

    Public Function getPorDNI(ByVal dni As Integer) As DataTable

        Dim Sql As String = "SELECT C.dni, C.nombre, C.apellido, C.telefono, C.direccion, C.email, P.descripcion_provincia FROM cliente C INNER JOIN provincia P ON C.provincia_id = P.id_provincia where dni = '  " & dni & " ' and estado=1 "
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Dim dt As DataTable = New DataTable()
        'da.Fill(dt)
        da.Fill(dt)
        Return dt


    End Function

    Public Function getPorApellido(ByVal apellido As String) As DataTable

        Dim Sql As String = "SELECT C.dni, C.nombre, C.apellido, C.telefono, C.direccion, C.email, P.descripcion_provincia FROM cliente C INNER JOIN provincia P ON C.provincia_id = P.id_provincia WHERE apellido LIKE '%" & apellido & "%' and estado=1"
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Dim dt As DataTable = New DataTable()
        'da.Fill(dt)
        da.Fill(dt)
        Return dt
    End Function


    Public Function getverificarDni(ByVal dni As Integer) As Boolean

        Dim Sql As String = "SELECT dni  FROM cliente where dni = '  " & dni & " '  "
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)
        
        Return True

    End Function



    Function ActualizarCli(ByVal cliente As ECliente) As Boolean

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM cliente", miconexion)

        Dim actualizar As String
        actualizar = "UPDATE  cliente SET dni=@dni, nombre=@nombre, apellido=@apellido,telefono=@telefono, direccion=@direccion,email=@email, provincia_id=@provincia, estado=@estado where dni=@dni"

        Dim cmdActualizar As New SqlCommand(actualizar, miconexion)

        cmdActualizar.Parameters.AddWithValue("@dni", cliente.Dni)
        cmdActualizar.Parameters.AddWithValue("@nombre", cliente.Nombre)
        cmdActualizar.Parameters.AddWithValue("@apellido", cliente.Apellido)
        cmdActualizar.Parameters.AddWithValue("@telefono", cliente.Telefono)
        cmdActualizar.Parameters.AddWithValue("@direccion", cliente.Direccion)
        cmdActualizar.Parameters.AddWithValue("@email", cliente.Email)
        cmdActualizar.Parameters.AddWithValue("@provincia", cliente.Provincia)
        cmdActualizar.Parameters.AddWithValue("@estado", cliente.Estado)
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

    Function delCliente(ByVal dni As Integer, ByVal estado As Integer) As Boolean

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM cliente", miconexion)

        Dim borrar As String
        borrar = "UPDATE cliente SET estado = @estado WHERE dni = @dni"

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

    Public Function getBuscar() As DataTable

        Dim Sql As String = "SELECT C.Dni, C.Nombre, C.Apellido, C.Telefono, C.Direccion, C.Email, P.Descripcion_provincia FROM cliente C INNER JOIN provincia P ON C.provincia_id = P.id_provincia where estado = 1  "
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Dim dt As DataTable = New DataTable()
        'da.Fill(dt)
        da.Fill(dt)
        Return dt


    End Function



End Class
