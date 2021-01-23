      protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<String> CountryID_list = new List<string>();
        List<String> CountryName_list = new List<string>();
        foreach (System.Web.UI.WebControls.ListItem item in ddchkCountry.Items)
        {
            if (item.Selected)
           {
               CountryID_list.Add(item.Value);
               CountryName_list.Add(item.Text);
           }
           lblCountryID.Text = "Country ID: "+ String.Join(",", CountryID_list.ToArray());
           lblCountryName.Text = "Country Name: "+ String.Join(",", CountryName_list.ToArray());
       } 
    }
