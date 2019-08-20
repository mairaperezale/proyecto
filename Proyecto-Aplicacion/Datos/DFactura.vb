Imports System.Data
Imports System.Data.SqlClient
Imports Entidad
Imports System.Configuration
Public Class DFactura


    Dim connectionString = ConfigurationManager.ConnectionStrings("conexionBD").ConnectionString
    Dim miconexion As SqlConnection = New SqlConnection(connectionString)

    Function agregarFactura(ByVal factura As EFactura) As Boolean
        Dim insertarEncabezado As String
        insertarEncabezado = "INSERT INTO factura(Fecha, Dni_Cliente,Total, Dni_Empleado) " & _
        "VALUES " & _
        " (@fecha,@dni_cliente, @total, @dni_empleado) "
        Dim cmdInsertar As New SqlCommand(insertarEncabezado, miconexion)
        'cmdInsertar.Parameters.AddWithValue("@id_factura", factura.IdFactura)
        cmdInsertar.Parameters.AddWithValue("@fecha", factura.Fecha)
        cmdInsertar.Parameters.AddWithValue("@dni_cliente", factura.Dni_Cliente)
        cmdInsertar.Parameters.AddWithValue("@total", factura.Total)
        cmdInsertar.Parameters.AddWithValue("@dni_empleado", factura.Dni_Empleado)
        'cmdInsertar.Parameters.AddWithValue("@estado", encabezado.Estado)
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

    Function agregarDetalle(ByVal detalle As EDetalle) As Boolean
        Dim objProducto As DProducto = New DProducto
        Dim insertarDetalle As String
        insertarDetalle = "INSERT INTO detalle(Factura_id, Codigo_producto,nombre, Cantidad, Precio,subtotal) " & _
        "VALUES " & _
        " (@factura_id,@codigo_Producto,@nombre, @cantidad, @precio,@subtotal) "
        Dim cmdInsertarDetalle As New SqlCommand(insertarDetalle, miconexion)
        cmdInsertarDetalle.Parameters.AddWithValue("@factura_id", detalle.FacturaId)
        cmdInsertarDetalle.Parameters.AddWithValue("@codigo_producto", detalle.CodigoProducto)
        cmdInsertarDetalle.Parameters.AddWithValue("@nombre", detalle.Nombre)
        cmdInsertarDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad)
        cmdInsertarDetalle.Parameters.AddWithValue("@precio", detalle.Precio)
        cmdInsertarDetalle.Parameters.AddWithValue("@subtotal", detalle.Subtotal)
        Try
            miconexion.Open()
            cmdInsertarDetalle.ExecuteNonQuery()
            'Actualiza el sotock
            objProducto.actualizarstock(detalle.CodigoProducto, detalle.Cantidad)
            Return (True)
        Catch ex As Exception
            Return False
        Finally
            miconexion.Close()
        End Try
    End Function

    'Function utimoId() As String
    '    Dim resultado As String = "select max(id_factura) from factura"
    '    Return resultado
    'End Function


    Public Function ultimoId() As DataTable

        Dim Sql As String = "SELECT max(id_factura +1) FROM factura "
        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Dim dt As DataTable = New DataTable()
        'da.Fill(dt)
        da.Fill(dt)
        Return dt


    End Function



    Public Function cargarfactura(ByVal valor As Integer) As DataTable

        Dim Sql As String = "SELECT D.Codigo_producto,D.Nombre,D.Precio, D.Cantidad,D.Subtotal FROM detalle D INNER JOIN factura F ON D.factura_id=F.id_factura where D.factura_id = '  " & valor & " '"



        Dim command As SqlCommand = New SqlCommand(Sql, miconexion)

        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)

        Dim dt As DataTable = New DataTable()
        'da.Fill(dt)
        da.Fill(dt)
        Return dt

    End Function



    Public Function probar()

        Dim SqlFactura As String = "select * from factura"
        'Dim sqlDetalle As String = "select * fro detalle"
        Dim command As SqlCommand = New SqlCommand(SqlFactura, miconexion)
        'Dim command1 As SqlCommand = New SqlCommand(sqlDetalle, miconexion)
        ' Inicializar un nuevo SqlDataAdapter 
        Dim da As New SqlDataAdapter(command)
        'Dim de As New SqlDataAdapter(command1)
        Dim dt As DataTable = New DataTable()
        'da.Fill(dt)
        da.Fill(dt)
        'de.Fill(dt)

    End Function
End Class
