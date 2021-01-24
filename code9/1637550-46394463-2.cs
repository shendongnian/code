    Private linkBtn As LinkButton ' Declare the LinkButton variable at a module level
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreInit
        linkBtn = New LinkButton()        
        linkBtn.Text = label
        linkBtn.CssClass = "myLinkBtn"
        linkBtn.CommandName = command.ToString
        linkBtn.CommandArgument = commandArgument
    
        AddHandler linkBtn.Click, AddressOf LinkButton_Click
    End Sub
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        ' During Init all the controls have been created
        panel.Controls.Add(linkBtn)
    End Sub
