Public Class EFactura
    Private _idFactura As Integer
    Private _fecha As Date
    Private _dniCliente As Integer
    Private _total As Decimal
    Private _dniEmpelado As Integer

    Property IdFactura As Integer
        Get
            Return _idFactura
        End Get
        Set(ByVal value As Integer)
            _idFactura = value
        End Set
    End Property

    Property Fecha As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property


    Property Dni_Cliente As Integer
        Get
            Return _dniCliente
        End Get
        Set(ByVal value As Integer)
            _dniCliente = value
        End Set
    End Property

    Property Total As Decimal
        Get
            Return _total
        End Get
        Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property

    Property Dni_Empleado As Integer
        Get
            Return _dniEmpelado
        End Get
        Set(ByVal value As Integer)
            _dniEmpelado = value
        End Set
    End Property
    
End Class
