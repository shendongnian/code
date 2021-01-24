    if (!IsPostBack)
    {  updateMenuItems();
    
    .........
        
    private void updateMenuItems()
    {
        string UserId = "?UserId=" + lblUserID.Text;
        
        foreach (MenuItem i in Menu1.Items)
        {
            i.NavigateUrl = i.NavigateUrl + UserId;
        }
    }
