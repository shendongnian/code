    using Xamarin.Forms;
    
    namespace RelativeLayoutButtonSample
    {
        public class ButtonPage : ContentPage
        {
            public ButtonPage()
            {
                const int relativeLayoutVerticalSpacing = 5;
    
                double buttonWidthPercentage;
                if (Device.Idiom.Equals(TargetIdiom.Phone))
                    buttonWidthPercentage = 0.9;
                else
                    buttonWidthPercentage = 0.5;
    
                var zeroButton = new Button
                {
                    Text = "0",
                    TextColor = Color.Black,
                    HeightRequest = 60,
                    BackgroundColor = Color.FromHex("2D7BF7"),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
    
                var oneButton = new Button
                {
                    Text = "1",
                    TextColor = Color.Black,
                    HeightRequest = 60,
                    BackgroundColor = Color.FromHex("2D7BF7"),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
    
                var twoButton = new Button
                {
                    Text = "2",
                    TextColor= Color.Black,
                    HeightRequest = 60,
                    BackgroundColor = Color.FromHex("2D7BF7"),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
    
                var fiveButton = new Button
                {
                    Text = "5",
                    TextColor = Color.Black,
                    HeightRequest = 60,
                    BackgroundColor = Color.FromHex("2D7BF7"),
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
    
                var relativeLayout = new RelativeLayout();
                relativeLayout.Children.Add(zeroButton,
                                            Constraint.RelativeToParent(parent => parent.Width * (1 - buttonWidthPercentage) / 2),
                                            Constraint.Constant(0),
                                            Constraint.RelativeToParent(parent => parent.Width * buttonWidthPercentage));
                relativeLayout.Children.Add(oneButton,
                                            Constraint.RelativeToParent(parent => parent.Width * (1 - buttonWidthPercentage) / 2),
                                            Constraint.RelativeToView(zeroButton, (parent, view) => view.Y + view.Height + relativeLayoutVerticalSpacing),
                                            Constraint.RelativeToParent(parent => parent.Width * buttonWidthPercentage));
                relativeLayout.Children.Add(twoButton,
                                            Constraint.RelativeToParent(parent => parent.Width * (1 - buttonWidthPercentage) / 2),
                                            Constraint.RelativeToView(oneButton, (parent, view) => view.Y + view.Height + relativeLayoutVerticalSpacing),
                                            Constraint.RelativeToParent(parent => parent.Width * buttonWidthPercentage));
                relativeLayout.Children.Add(fiveButton,
                                            Constraint.RelativeToParent(parent => parent.Width * (1 - buttonWidthPercentage) / 2),
                                            Constraint.RelativeToView(twoButton, (parent, view) => view.Y + view.Height + relativeLayoutVerticalSpacing),
                                            Constraint.RelativeToParent(parent => parent.Width * buttonWidthPercentage));
    
                Content = relativeLayout;
    
                Padding = new Thickness(0, 20);
    
                Title = $"Button Page on a {Device.Idiom}";
            }
        }
    
    	public class App : Application
    	{
    		public App()
    		{
    			MainPage = new NavigationPage(new ButtonPage());
    		}
    	}
    }
