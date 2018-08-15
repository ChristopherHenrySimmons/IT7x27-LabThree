Imports System.Data.SqlClient

Public Class Service1
    Implements IService1

    Public Function Reserve(ByVal seatType As String, ByVal classType As String) As Boolean Implements IService1.Reserve

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
        objParameter1.Value = seatType

        Dim objParameter2 As New SqlParameter("@classType", SqlDbType.VarChar, 50)
        objCommand.Parameters.Add(objParameter2)
        objParameter2.Direction = ParameterDirection.Input
        objParameter2.Value = classType

        Dim objOutputParameter As New SqlParameter("@Response", SqlDbType.Bit)
        objCommand.Parameters.Add(objOutputParameter)
        objOutputParameter.Direction = ParameterDirection.Output

        objConnection.Open()

        objCommand.ExecuteNonQuery()
        retValue = objCommand.Parameters("@Response").Value
        objConnection.Close()

        If retValue Then Return True

        Return False


    End Function

End Class