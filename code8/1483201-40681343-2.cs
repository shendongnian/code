    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If IsPostBack Then
    Else
        Populate_Activity_DDL()
    End If
    End Sub
