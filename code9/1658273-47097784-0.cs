        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=MyDB.accdb")
        con.Open()
        Dim da As New OleDbDataAdapter("SELECT * FROM MyTable",con)
        Dim dt As New DataTable
        da.Fill(dt)
        For Each column As DataColumn In dt.Columns
            Dim columnName = column.ColumnName
        Next
