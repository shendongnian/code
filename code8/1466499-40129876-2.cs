    private void AvoidDuplicate()
        {
    
            for (int i = 0; i < grdView.Rows.Count; i++)
            {
                TextBox txtoldvalue = grdView.Rows[i].FindControl("txtLicenseNumber") as TextBox;
                string oldvalue = txtoldvalue.Text.ToString();
    
                Label txtoldvalueJ = grdView.Rows[i].FindControl("lblJurisdiction") as Label;
                string oldvalueJ = txtoldvalueJ.Text.ToString();
    
                if (oldvalue != "" || oldvalueJ !="")  
                {
                    for (int j = i+1; j < grdView.Rows.Count; j++)
                    {
                        TextBox txtnewvalue = grdView.Rows[j].FindControl("txtLicenseNumber") as TextBox;
                        string newvalue = txtnewvalue.Text.ToString();
    
                        Label txtnewvalueJ = grdView.Rows[j].FindControl("lblJurisdiction") as Label;
                        string newvalueJ = txtnewvalueJ.Text.ToString();
    
                            if (oldvalue != newvalue || oldvalueJ != newvalueJ)
                            {
                                grdView.Rows[i].Visible = true;
                            }
                            else
                            {
                                grdView.Rows[i].Visible = false;
                                break;
                            }
                        }
                }
            }
        }
