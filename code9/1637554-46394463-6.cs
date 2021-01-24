    Private linkBtn As LinkButton ' Declare the LinkButton variable at a module level
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreInit
        linkBtn = New LinkButton()        
        linkBtn.Text = "Test"
        linkBtn.CssClass = "myLinkBtn"
        linkBtn.CommandName = CommandType.PageLink.ToString
        linkBtn.CommandArgument = "EntityPage"
    
        AddHandler linkBtn.Click, AddressOf LinkButton_Click
    End Sub
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        ' During Init all the controls have been created.
        ' During the PreInit event the "panel" control is unavailable.
        panel.Controls.Add(linkBtn)
    End Sub
