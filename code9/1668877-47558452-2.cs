    public class MainPageNew : ContentPage
        {
            public MainPageNew()
            {
                StackLayout parent = new StackLayout();
                Button button = new Button
                {
                    BackgroundColor = Color.Red,
                    Font = Font.Default,
                    FontSize = 10,
                    TextColor = Color.White,
                    HeightRequest = 300,
                    WidthRequest = 80
                };
    
                //button.Image = "media_step_back.png";
                button.Image = "xamarin.png";
    
                parent.Children.Add(button);
    
                this.Content = parent;
            }
