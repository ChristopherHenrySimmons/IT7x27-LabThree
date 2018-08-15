Imports System.Data.SqlClient
Imports System.Data

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objConnection As SqlConnection
        Dim objCommand As SqlCommand
        Dim retValue As Boolean

        'change
        objConnection = New SqlConnection("Data Source=PE203-30\MSSQLSVR;Initial Catalog=TICKETS;Integrated Security=True")
        objCommand = New SqlCommand("Reserve", objConnection)
        objCommand.CommandType = CommandType.StoredProcedure

        Dim objParameter1 As New SqlParameter("@seatType", SqlDbType.VarChar, 50)
        objCommand.Parameters.Add(objParameter1)
        objParameter1.Direction = ParameterDirection.Input
        objParameter1.Value = seatType.Text

        Dim objParameter2 As New SqlParameter("@classType", SqlDbType.VarChar, 50)
        objCommand.Parameters.Add(objParameter2)
        objParameter2.Direction = ParameterDirection.Input
        objParameter2.Value = classType.Text

        Dim objOutputParameter As New SqlParameter("@Response", SqlDbType.Bit)
        objCommand.Parameters.Add(objOutputParameter)
        objOutputParameter.Direction = ParameterDirection.Output

        objConnection.Open()

        objCommand.ExecuteNonQuery()
        retValue = objCommand.Parameters("@Response").Value
        objConnection.Close()

        TextBox1.Text = retValue.ToString

    End Sub
End Class