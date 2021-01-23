    private void AvoidDuplicate()
    {
      Dictionary<string,string> checkdictionary=new Dictionary<string,string>();
        
        for (int i = 0; i < grdView.Rows.Count; i++)
        {
            TextBox txtnewvalue = grdView.Rows[i].FindControl("txtLicenseNumber") as TextBox;
                string newvalue = txtnewvalue.Text.ToString();
            if(!checkdictionary.ContainsKey(newvalue))
            {
                 checkdictionary[newvalue]="something";
            }
            else
            {
              grdView.Rows[i].Visible = false;
            }
            
        }
    }
