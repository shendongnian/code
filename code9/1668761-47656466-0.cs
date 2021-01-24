    Roles.IsUserInRole
     try
      {
        if (!Roles.IsUserInRole(User.Identity.Name, "Administrators"))
        {
          Msg.Text = "You are not authorized to view user roles.";
          UsersListBox.Visible = false;
          return;
        }
      }
      catch (HttpException e)
      {
        Msg.Text = "There is no current logged on user. Role membership cannot be verified.";
        return;
      }
