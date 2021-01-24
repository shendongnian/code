    private bool _isSelected;
    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
       _isSelected = true;
    }
    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
       if(!_isSelected)
       {
          //do work here
       }
       _isSelected = false;
    }
