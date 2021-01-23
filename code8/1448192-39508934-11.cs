       protected void dropdown1_SelectedIndexChanged(object sender, EventArgs e)
     {
         List<String> checkedList = new List<string>();
         //List<String> CountryName_list = new List<string>();
         foreach (System.Web.UI.WebControls.ListItem item in dropdown1.Items)
         {
            if (item.Selected)
            {
                //CountryID_list.Add(item.Value);
                checkedList.Add(item.Text);
            }
            //I don't know the ID/name of your textbox. You need to change that here:
             myTextBox.Text = String.Join(",", checkedList);
             //lblCountryName.Text = "Country Name: "+ String.Join(",", CountryName_list.ToArray());
         } 
    }
