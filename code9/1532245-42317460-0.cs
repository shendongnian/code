    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
    if (lbUsername.Text.Contains(userName))
    {
        lbUsername.Text = "klik op de knop, dokus.";
    }
    else
    {
        lbUsername.Text = "Username: Hallo," + userName;
    }
