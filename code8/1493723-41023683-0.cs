     int custID;
     if(!Int32.TryParse(txtMembershipID.Text, out custID))
     {
        MessageBox.Show("Invalid number");
        return;
     }
     cc.cmd.Parameters.Add("@d1", SqlDbType.Int).Value = custID;
