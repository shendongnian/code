    Public Class Form1
        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    
            Dim mec As New MaskedEditColumn
            mec.Mask = ""
            mec.DataPropertyName = "Data"
            Me.DataGridView1.Columns.Add(mec)
    
    
            Dim tbl As New Data.DataTable
            tbl.Columns.Add("Data")
            tbl.Columns.Add("Mask")
            tbl.Rows.Add(New Object() {"The quick brown fox j   ed over the lazy hound", "The quick brown fox jaaaed over the l\azy hound"})
            tbl.Rows.Add(New Object() {"    quick brown fox j   ed over the lazy hound", "aaa quick brown fox jaaaed over the l\azy hound"})
            tbl.Rows.Add(New Object() {"The       brown fox j   ed over the lazy hound", "The aaaaa brown fox jaaaed over the l\azy hound"})
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = tbl
        End Sub
    
        Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
    
            If e.Control.GetType().Equals(GetType(MaskedEditingControl)) Then
    
                Dim mec As MaskedEditingControl = e.Control
                Dim row As DataGridViewRow = Me.DataGridView1.CurrentRow
                mec.Mask = row.DataBoundItem("Mask")
    
            End If
    
        End Sub
    End Class
  
