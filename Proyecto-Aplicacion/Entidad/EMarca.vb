Public Class EMarca

    Private _marca As Integer
    Private _descripcion As String

    Property Marca As Integer
        Get
            Return _marca
        End Get
        Set(ByVal value As Integer)
            _marca = value
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
