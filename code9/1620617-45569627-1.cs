        ' SQLCommand to fill DataTable
        Dim dt As New DataTable
        Using cnn As New SqlConnection("someconnectionstring")
            Dim cmd As New SqlCommand("SELECT * FROM SomeTable", cnn)
            cnn.Open()
            dt.Load(cmd.ExecuteReader)
            cnn.Close()
        End Using
        ' TableAdapter to fill DataSet
        Dim ds As New DataSet
        Dim ta As New SqlDataAdapter
        ta.Fill(ds)
    
    The [Using statement][1] lets .NET handle the disposal of the connection for you.
