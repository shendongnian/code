    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
    // Make a countryList where we store all country IDs. change this to however you wanna use it urself
    List<int> countryList = new List<int>();
    foreach (ListItem country in ddlCountry.Items)
    {
     if(country.selected){
     {
    //we add the ID of the country. 
     countryList.Add(country.ID)
     }
    }
