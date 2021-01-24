    List<DropDownList> ddlNames;
    List<DropDownList> ddlLocations;
    protected void btnValues_Click(object sender, EventArgs e)   
    { 
         if (dllNames.Count() == ddlLocations.Count())
         {
             for (int i = 0; i < ddlNames.Count(); i++)
             {
                  strDDLValue = string.Format("{0},{1}", 
                   ddlNames[i].SelectedItem.Text,
                   ddlLocations[i].SelectedItem.Text );
             }
         }
    }
