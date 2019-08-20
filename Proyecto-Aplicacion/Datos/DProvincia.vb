Imports System.Data
Imports System.Data.SqlClient
Imports Entidad
Imports System.Configuration
Public Class DProvincia

    Dim connectionString = ConfigurationManager.ConnectionStrings("conexionBD").ConnectionString

    Dim miconexion As SqlConnection = New SqlConnection(connectionString)


    Public Function getAll() As List(Of EProvincia)

        Dim command As SqlCommand = New SqlCommand("SELECT * FROM provincia", miconexion)

        miconexion.Open()

        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim listaProvincia As New List(Of EProvincia)

        Do While reader.Read()

            Dim item As EProvincia = New EProvincia
            item.Provincia = reader("id_provincia")
            item.Descripcion = reader("descripcion_provincia")

            listaProvincia.Add(item)
        Loop
        miconexion.Close()
        Return listaProvincia

    End Function


End Class
