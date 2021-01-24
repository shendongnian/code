       var buttonnew = new Button
            {
                Text = "Click Me!",
                BackgroundColor = Color.FromHex("FF5A5F"),
                FontSize = 24                
            };
       buttonnew.Clicked += async (sender, args) =>
            {
                buttonnew.IsEnabled = false;
                // do your onclick process here
            };
         MainPage = new ContentPage
            {         
                BackgroundColor = Color.FromHex("BFD7EA"),
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                       
                        buttonnew,
                       
                       
                    }
                }
            };
