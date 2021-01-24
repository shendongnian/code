     protected override void OnAppearing()
        {
                base.OnAppearing();
                s = new MyPopupPage();
                PopupNavigation.PushAsync(s, true);
         
            
        }
