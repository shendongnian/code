     async void OnBtClick(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new ContentPage
                {
                    Content = new StackLayout
                    {
                        VerticalOptions = LayoutOptions.Center,
                        Children = {
                            new Button {
                               
                                Text = "button1"
                            },
                            new Button {
    
                               Text = "button2"
                            },
                            new Button {
    
                                Text = "button3"
                            }
                        }
                    }
                });
            }
