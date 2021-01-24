    if (G.SelectAdmin().Rows.Count != 0)
    {
      e.Authenticated = true;
      Login1.DestinationPageUrl = "Default.aspx";
      Roles.AddUserToRole(G.username, "SomeRole");  
    }
    
