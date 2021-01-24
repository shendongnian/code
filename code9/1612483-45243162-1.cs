    listView.ItemSelected += async (sender, e) =>
    {
        if (e.SelectedItem != null) {
          string selectedItem = e.SelectedItem.ToString();
          // clear selected item
          listView.SelectedItem = null;
          var detailsPage = new ItemDetails(selectedItem); 
          await Navigation.PushAsync(detailsPage);
        }
    };
