    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As 
    System.Web.UI.WebControls.GridViewRowEventArgs) Handles 
    GridView1.RowDataBound
    If e.Row.RowType = DataControlRowType.DataRow Then
    Dim gender As String = 
    Convert.ToString(e.Row.Cells(columnnumber).Text).Trim()
    If gender= "1" Then
    e.Row.Cells(columnnumber).Text = "Male"
    Else if gender="2" Then
    e.Row.Cells(columnnumber).Text="Female"   `
    End If
    End Sub
