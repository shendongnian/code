    private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
    var item = (MasterPageItem)e.SelectedItem;
    Type page = item.TargetType;
    // Detail = new NavigationPage((Page)Activator.CreateInstance(page));
    Detail.Navigation.PushAsync((Page)Activator.CreateInstance(page));
    IsPresented = false;
    }
