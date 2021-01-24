      private void OnModeChosen(object sender, EventArgs e)
        {
             Country country = ((Country)(e.item)) // get the country object from  the picker
              picker2.ItemsSource =  GetRegions(country.CountryId ) // call the function to get the regions for that country
              picker2.ItemDisplayBinding = New Binding("RegionsName")
              picker2.SelectedIndex = 0 // not sure why I did this, I think to make sure an item was selected
            stackpicker2.IsVisible = true // make the stack layout visible with the 2nd picker
            picker2.IsEnabled = true;
        }
