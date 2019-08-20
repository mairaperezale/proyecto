Public Class EProvincia
    Private _provincia As Integer
    Private _descripcion As String

    Property Provincia As Integer
        Get
            Return _provincia
        End Get
        Set(ByVal value As Integer)
            _provincia = value
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
End Class
