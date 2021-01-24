    Private Function GetColIdx(MyStringName As String)
        Dim ColIdx As Int16
        For ic = 0 To Me.DataGridView1.Columns.Count - 1
            Dim dc As DataGridViewColumn = Me.DataGridView1.Rows(ic)
            If dc.Name = MyStringName Then
                ColIdx = ic
                Exit For
            End If
        Next
        Return ColIdx
    End Function
