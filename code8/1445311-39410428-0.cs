    private bool CheckUserAvailability()
    {
            SystemUserBL bl = new SystemUserBL(SessionContext.SystemUser);
            ds = new DataSet();
            bl.FetchForLoginEmailAddress(ds, txtLoginEmailAddress.Text);
    
            if (ds.Tables[0].Rows.Count > 0)
            {
                valDuplicatePassword.Visible = true;
                valDuplicatePassword.Text = "<b>This User Name is already in use by another user.</b>";
                return true;
                }
                else
                 {
                  valDuplicatePassword.Visible = true;
                  valDuplicatePassword.Text = "<b>Congratulations! " + txtLoginEmailAddress.Text + " is available.</b>";
                  return false;
                }
     }
