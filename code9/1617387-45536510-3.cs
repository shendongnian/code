    using Xamarin.Forms;
    
    namespace HorizontalButtonSampleApp
    {
        public class ButtonPage : ContentPage
        {
            public ButtonPage()
            {
                const int relativeLayoutHorizontalSpacing = 5;
                const int numberOfButtons = 4;
    
                double screenUsePercentage;
                if (Device.Idiom.Equals(TargetIdiom.Phone))
                    screenUsePercentage = 0.9;
                else
                    screenUsePercentage = 0.5;
    
                var zeroButton = new StyledButton { Text = "0" };
                var oneButton = new StyledButton { Text = "1" };
                var twoButton = new StyledButton { Text = "2" };
                var fiveButton = new StyledButton { Text = "5" };
    
                var relativeLayout = new RelativeLayout();
                relativeLayout.Children.Add(zeroButton,
                                            Constraint.RelativeToParent(parent => parent.Width * (1 - screenUsePercentage) / 2),
                                            Constraint.Constant(0),
                                            Constraint.RelativeToParent(parent => (parent.Width * screenUsePercentage - relativeLayoutHorizontalSpacing * (numberOfButtons - 1)) / numberOfButtons));
                relativeLayout.Children.Add(oneButton,
                                            Constraint.RelativeToView(zeroButton, (parent, view) => view.X + view.Width + relativeLayoutHorizontalSpacing),
                                            Constraint.Constant(0),
                                            Constraint.RelativeToParent(parent => (parent.Width * screenUsePercentage - relativeLayoutHorizontalSpacing * (numberOfButtons - 1)) / numberOfButtons));
                relativeLayout.Children.Add(twoButton,
                                            Constraint.RelativeToView(oneButton, (parent, view) => view.X + view.Width + relativeLayoutHorizontalSpacing),
                                            Constraint.Constant(0),
                                            Constraint.RelativeToParent(parent => (parent.Width * screenUsePercentage - relativeLayoutHorizontalSpacing * (numberOfButtons - 1)) / numberOfButtons));
                relativeLayout.Children.Add(fiveButton,
                                            Constraint.RelativeToView(twoButton, (parent, view) => view.X + view.Width + relativeLayoutHorizontalSpacing),
                                            Constraint.Constant(0),
                                            Constraint.RelativeToParent(parent => (parent.Width * screenUsePercentage - relativeLayoutHorizontalSpacing * (numberOfButtons - 1)) / numberOfButtons));
                
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
    
        public class StyledButton : Button
        {
            public StyledButton()
            {
                TextColor = Color.Black;
                HeightRequest = 60;
                BackgroundColor = Color.FromHex("2D7BF7");
                HorizontalOptions = LayoutOptions.FillAndExpand;
                VerticalOptions = LayoutOptions.CenterAndExpand;
            }
        }
    }
