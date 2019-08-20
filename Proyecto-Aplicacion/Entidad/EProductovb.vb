Public Class EProductovb
    Private _codigo As Integer
    Private _nombre As String
    Private _precio As Integer
    Private _stock As Integer
    Private _descripcion As String
    Private _marca As Integer
    Private _estado As Integer

    Property Codigo As Integer
        Get
            Return _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
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

    Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
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

    Property Stock As Integer
        Get
            Return _stock
        End Get
        Set(ByVal value As Integer)
            _stock = value
        End Set
    End Property
    Property Marca As Integer
        Get
            Return _marca
        End Get
        Set(ByVal value As Integer)
            _marca = value
        End Set
    End Property

    Property Estado As Integer
        Get
            Return _estado
        End Get
        Set(ByVal value As Integer)
            _estado = value
        End Set
    End Property
End Class
