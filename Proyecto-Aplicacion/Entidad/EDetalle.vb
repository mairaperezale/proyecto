Public Class EDetalle
    Private _facturaId As Integer
    Private _codigo_producto As Integer
    Private _nombre As String
    Private _cantidad As Integer
    Private _precio As Integer
    Private _subtotal As Integer

    Property FacturaId As Integer
        Get
            Return _facturaId
        End Get
        Set(ByVal value As Integer)
            _facturaId = value
        End Set
    End Property

    Property CodigoProducto As Integer
        Get
            Return _codigo_producto
        End Get
        Set(ByVal value As Integer)
            _codigo_producto = value
        End Set
    End Property


    Property Cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Property Precio As Integer
        Get
            Return _precio
        End Get
        Set(ByVal value As Integer)
            _precio = value
        End Set
    End Property


    Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Property Subtotal As Integer
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Integer)
            _subtotal = value
        End Set
    End Property
End Class
