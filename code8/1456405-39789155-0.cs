     private void AvoidDuplicate()
            {
                for (int i = 0; i < grdView.Rows.Count; i++)
                {
                    TextBox txtoldvalue = grdView.Rows[i].FindControl("txtLicenseNumber") as TextBox;
                    string oldvalue = txtoldvalue.Text.ToString();
        
                    for (int j = 0; j < grdView.Rows.Count; j++)
                    {
                       if( j = i)
                         continue;
    TextBox txtnewvalue = grdView.Rows[j].FindControl("txtLicenseNumber") as TextBox;
                        string newvalue = txtnewvalue.Text.ToString();
                        if (oldvalue == newvalue)
                        {
                            grdView.Rows[j].Visible = false;
                        }
                    }
                }
            }
