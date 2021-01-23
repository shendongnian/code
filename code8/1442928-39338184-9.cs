     Public Shared Function GetContactName(ByVal custid As String) As String
        If custid Is Nothing OrElse custid.Length = 0 Then
            Return String.Empty
        End If
        Dim conn As SqlConnection = Nothing
        Try
            Dim connection As String = ConfigurationManager.ConnectionStrings("NorthwindConnectionString").ConnectionString
            conn = New SqlConnection(connection)
            Dim sql As String = "Select ContactName from Customers where CustomerId = @CustID"
            Dim cmd As SqlCommand = New SqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("CustID", custid)
            conn.Open()
            Dim contNm As String = Convert.ToString(cmd.ExecuteScalar())
            Return contNm
        Catch ex As SqlException
            Return "error"
        Finally
            conn.Close()
        End Try
    End Function
