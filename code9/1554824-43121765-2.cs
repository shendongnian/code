    private void ItemClickEvent(object sender, ItemClickEventArgs e)
    {
    	YourClassName selectedFilm = e.ClickedItem as YourClassName;
    	if(selectedFilm != null)
    	{
    		this.Frame.Navigate(typeof(FilmInfo), selectedFilm.Id);
    	}
    }
