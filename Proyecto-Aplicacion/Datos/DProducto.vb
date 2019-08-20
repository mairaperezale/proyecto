Imports Entidad
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class DProducto

    Dim connectionString = ConfigurationManager.ConnectionStrings("conexionBD").ConnectionString

    Dim miconexion As SqlConnection = New SqlConnection(connectionString)


    Public Function getAll() As List(Of EProductovb)

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM producto", miconexion)

        miconexion.Open()

        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim listaProducto As New List(Of EProductovb)

        Do While reader.Read()

            Dim item As EProductovb = New EProductovb

            item.Codigo = reader("codigo")
            item.Nombre = reader("nombre")
            item.Precio = reader("precio")
            item.Stock = reader("stock")
            item.Descripcion = reader("descripcion")
            item.Marca = reader("marca_id")

            listaProducto.Add(item)
        Loop
        miconexion.Close()
        Return listaProducto


    End Function


    Function agregar(ByVal producto As EProductovb) As Boolean

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM producto", miconexion)

        Dim insertar As String
        insertar = "INSERT INTO  producto(codigo, nombre, precio, stock, descripcion, marca_id,estado) " & _
      "VALUES " & _
      " (@codigo,@nombre,@precio,@stock,@descripcion, @marca,@estado) "

        Dim cmdInsertar As New SqlCommand(insertar, miconexion)

        cmdInsertar.Parameters.AddWithValue("@codigo", producto.Codigo)
        cmdInsertar.Parameters.AddWithValue("@nombre", producto.Nombre)
        cmdInsertar.Parameters.AddWithValue("@precio", producto.Precio)
        cmdInsertar.Parameters.AddWithValue("@stock", producto.Stock)
        cmdInsertar.Parameters.AddWithValue("@descripcion", producto.Descripcion)
        cmdInsertar.Parameters.AddWithValue("@marca", producto.Marca)
        cmdInsertar.Parameters.AddWithValue("@estado", producto.Estado)
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

    Function delProducto(ByVal codigo As Integer, ByVal estado As Integer) As Boolean

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM producto", miconexion)

        Dim borrar As String
        borrar = "UPDATE producto SET estado = @estado WHERE codigo = @codigo"

        Dim cmdActualizar As New SqlCommand(borrar, miconexion)

        cmdActualizar.Parameters.AddWithValue("@codigo", codigo)
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
    Public Function getPorPorYMar() As DataTable

        Dim Sql As String = "SELECT P.Codigo, P.Nombre, P.Precio, P.Stock,P.Descripcion, C.Descripcion,P.estado FROM producto P INNER JOIN marca C ON P.marca_id = C.id_marca"
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Dim dt As DataTable = New DataTable()
        'da.Fill(dt)
        da.Fill(dt)
        Return dt

    End Function

    Public Function getPorID(ByVal Id As Integer) As DataTable

        Dim Sql As String = "SELECT P.codigo, P.nombre, P.precio, P.stock,P.descripcion, C.descripcion FROM producto P INNER JOIN marca C ON P.marca_id = C.id_marca where P.marca_id = '  " & Id & " ' and estado=1 "
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Dim dt As DataTable = New DataTable()
        'da.Fill(dt)
        'da.Fill(dt)
        da.Fill(dt)
        Return dt




    End Function

    Public Function getPorDescripcion(ByVal desc As String) As DataTable


        Dim Sql As String = "SELECT P.codigo, P.nombre, P.precio, P.stock,P.descripcion, C.descripcion FROM producto P INNER JOIN marca C ON P.marca_id = C.id_marca where P.descripcion LIKE '%" & desc & "%' and estado=1"
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Dim dt As DataTable = New DataTable()
        da.Fill(dt)
        Return dt

    End Function


    Public Function getverificar(ByVal codigo As Integer) As Boolean

        Dim Sql As String = "SELECT codigo  FROM producto where codigo = '  " & codigo & " '  "
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Return True

    End Function



    Function ActualizarPro(ByVal producto As EProductovb) As Boolean

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM producto", miconexion)

        Dim actualizar As String
        actualizar = "UPDATE  producto SET codigo=@codigo, nombre=@nombre, precio=@precio,stock=@stock, descripcion=@descripcion,marca_id=@marca where codigo=@codigo"

        Dim cmdActualizar As New SqlCommand(actualizar, miconexion)

        cmdActualizar.Parameters.AddWithValue("@codigo", producto.Codigo)
        cmdActualizar.Parameters.AddWithValue("@nombre", producto.Nombre)
        cmdActualizar.Parameters.AddWithValue("@precio", producto.Precio)
        cmdActualizar.Parameters.AddWithValue("@stock", producto.Stock)
        cmdActualizar.Parameters.AddWithValue("@descripcion", producto.Descripcion)
        cmdActualizar.Parameters.AddWithValue("@marca", producto.Marca)

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

        Dim Sql As String = "SELECT P.Codigo, P.Nombre, P.Precio, P.Stock,P.Descripcion, C.Descripcion FROM producto P INNER JOIN marca C ON P.marca_id = C.id_marca  where estado = 1  "
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Dim dt As DataTable = New DataTable()
        'da.Fill(dt)
        da.Fill(dt)
        Return dt


    End Function


    Public Sub actualizarstock(ByVal codigo As Integer, ByVal cantidad As Integer)
        Dim command As SqlCommand = New SqlCommand("SELECT * FROM producto WHERE codigo = " & codigo & " ", miconexion)
        miconexion.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()
        Dim stock As Integer
        Dim stockActual As Integer
        If reader.Read Then
            stock = reader("stock")
            stockActual = stock - cantidad
            reader.Close()
        End If
        'Se actualiza el Stock
        Dim actualizar As String = "UPDATE producto SET stock = @stock WHERE codigo = @codigo"
        Dim cmdActualizar As New SqlCommand(actualizar, miconexion)
        cmdActualizar.Parameters.AddWithValue("@codigo", codigo)
        cmdActualizar.Parameters.AddWithValue("@stock", stockActual)
        cmdActualizar.ExecuteNonQuery()
        miconexion.Close()
    End Sub
End Class
