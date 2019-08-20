Public Class ECliente

    Private _dni As Integer
    Private _nombre As String
    Private _apellido As String
    Private _telefono As Integer
    Private _direccion As String
    Private _email As String
    Private _provincia As Integer
    Private _estado As Integer


    Property Dni As Integer
        Get
            Return _dni
        End Get
        Set(ByVal value As Integer)
            _dni = value
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

    Property Apellido As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property
    Property Telefono As Integer
        Get
            Return _telefono
        End Get
        Set(ByVal value As Integer)
            _telefono = value
        End Set
    End Property

    Property Direccion As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Property Email As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Property Provincia As Integer
        Get
            Return _provincia
        End Get
        Set(ByVal value As Integer)
            _provincia = value
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
