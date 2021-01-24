    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    
    
        Dim headers = (From header As DataGridViewColumn In DataGridView1.Columns.Cast(Of DataGridViewColumn)() Select header.HeaderText).ToArray
        Dim rows = From row As DataGridViewRow In DataGridView1.Rows.Cast(Of DataGridViewRow)() Where Not row.IsNewRow Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))
        Dim str As String = ""
        Using sw As New IO.StreamWriter("C:\Users\Excel\Desktop\OrdersTest.csv")
            sw.WriteLine(String.Join(",", headers))
            'sw.WriteLine(String.Join(","))
            For Each r In rows
                sw.WriteLine(String.Join(",", r))
            Next
            sw.Close()
        End Using
    
    End Sub
