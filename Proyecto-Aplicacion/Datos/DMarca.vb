Imports System.Data
Imports System.Data.SqlClient
Imports Entidad
Imports System.Configuration
Public Class DMarca

    Dim connectionString = ConfigurationManager.ConnectionStrings("conexionBD").ConnectionString

    Dim miconexion As SqlConnection = New SqlConnection(connectionString)


    Public Function getAll() As List(Of EMarca)

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM marca", miconexion)

        miconexion.Open()

        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim listaMarca As New List(Of EMarca)

        Do While reader.Read()

            Dim item As EMarca = New EMarca
            item.Marca = reader("id_marca")
            item.Descripcion = reader("descripcion")

            listaMarca.Add(item)
        Loop
        miconexion.Close()
        Return listaMarca

    End Function

End Class
