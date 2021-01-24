    private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var item = e.SelectedItem as MasterPageItem;
        if (item == null)
            return;
        //  Check if sign out was tapped
        if (item.TargetType != null)
        {
            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            Detail = new NavigationPage(page);
            IsPresented = false;
        }
        else
        {
            //  Manage your sign out action
            var result = await this.DisplayAlert("Alert!", "Do you really want to exit?", "Yes", "No");
            if (result == true)
            {
                App.AuthenticationClient.UserTokenCache.Clear(Constants.ApplicationID);
                Application.Current.MainPage = new NavigationPage(new NewPageLogin());
            }
        }
    }
