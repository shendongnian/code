    private void btnLoad_Click(object sender, EventArgs e)
      {
       DCApp db = DCApp.NewDC();
    
       User logedUser = db.Users.FirstOrDefault(s => s == Program._user);
    
       List<Society> ListSociety = db.Societies.Where(s => s.UserID == logedUser.ID).ToList();  
    
       _bindingSource.DataSource = ListSociety;
       dgwUser.DataSource = _bindingSource;
       dgwUser.Refresh();
       _bindingSource.ResetBindings(false);    
      }
