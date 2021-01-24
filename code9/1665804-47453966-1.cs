      protected override bool OnBackButtonPressed()
                {
                    Device.BeginInvokeOnMainThread(async () => {
                        Application.Current.MainPage = new DrawerPage();
                    });
        
                    return true;
                }
