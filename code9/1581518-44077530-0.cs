    public void setSearch( )
    {
        if(!Page.IsPostBack) {
            // First page access
            search = txtBoxSearch.Text;
        } else {
            // The page has been reloaded
            search = txtBoxSearch.Text;
          }
    }
