var item = e.SelectedItem as TableMainMenuItems;
    async void lvMain_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var listView = sender as ListView;
        if (e.SelectedItem is TableMainMenuItems item)
        {
            switch (item.display_text)
            {
                case "Forms List":
                    await Navigation.PushAsync(new FormsListPage());
                    break;
                case "New Pre-Job":
                    await Navigation.PushAsync(new PreJobPage(intPreJobFormID));
                    break;
            }
            listView.SelectedItem = null;
        }
    }
