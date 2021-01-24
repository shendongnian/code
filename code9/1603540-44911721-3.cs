    private async void ItemSelectedMethod()
            {
    
                if (SelectedItem == Items[0])
                {
                    App.RootPage.Detail = new NavigationPage(mainPage);
                }
                if (SelectedItem == Items[1])
                {
                    App.RootPage.Detail = new NavigationPage(secondPage);
                }
                if (SelectedItem == Items[2])
                {
                    App.RootPage.Detail = new NavigationPage(thirdPage);
                }
                rootPageViewModel.IsPresented = false;
            }
