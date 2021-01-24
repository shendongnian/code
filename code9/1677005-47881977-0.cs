    void OnSelection (object sender, SelectedItemChangedEventArgs e)
    {
      if (e.SelectedItem == null) {
        return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
      }
      // get the selected Songs object
      var songs = (Songs)e.SelectedItem;
      // pass the Artists collection to the next page
      Navigation.PushAsync(new ArtistsPage(songs.Artists));
    }
