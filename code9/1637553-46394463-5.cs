    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim application As IApplication
    
        If Not IsPostBack Then    
            application = Session("App")             
            linkBtn.Visible = application IsNot Nothing
        
            If linkBtn.Visible Then
                ' Remove that next line
                ' AddLinkButton("Test", "EntityPage", CommandType.PageLink)
                ShowData(application)
            End If
        End If
    End Sub
