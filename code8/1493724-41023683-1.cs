     .... string columns could get directly from the Text property
     .... date columns need a DateTime parameter as well as int columns
     int memberID;
     if(!Int32.TryParse(txtMembershipID.Text, out memberID))
     {
        MessageBox.Show("Invalid number");
        return;
     }
     cc.cmd.Parameters.Add("@d3", SqlDbType.Int).Value = memberID;
