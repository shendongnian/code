    private async void lvMain_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var lv = (ListView)sender;
        if (e.SelectedItem == null)
        {
            return;
        }
        var item = e.SelectedItem as TableMainMenuItems;
        switch (item.display_text)
        {
            case "Forms List":
                await Navigation.PushAsync(new FormsListPage());
                break;
            case "New Pre-Job":
                await Navigation.PushAsync(new PreJobPage(intPreJobFormID));
                break;
        }
        lv.SelectedItem = null;
    }
