       Dim records As New List(Of TestRecord)
        Dim context As New DataTable()
        context.Columns.Add("DataTableRecordID")
        context.Columns.Add("Name")
        For i As Integer = 0 To 100
            records.Add(New TestRecord With {
                .RecordsID = i,
                .Name = "TestUser" & i.ToString()})
            context.Rows.Add(i, "TestUser" & i.ToString())
        Next
        Dim FinalResult = From p In context.AsEnumerable()
                          Join a In records.AsEnumerable() On p.Field(Of String)("DataTableRecordID") Equals a.RecordsID
