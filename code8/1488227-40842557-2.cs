    public class ProfileCell: ViewCell
    {
        private static int photoSize = 100;
        private static int viewCellPadding = 15;
    
        public ProfileCell(string imageSource, string description)
        {
            var photo = new ImageCircle
            {
                Source = imageSource,
                WidthRequest = photoSize,
                HeightRequest = photoSize,
                HorizontalOptions = LayoutOptions.Center,
                Aspect = Aspect.AspectFill,
                Scale = 1.0
            };
            
            Height = photoSize + (viewCellPadding * 2);
            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                Padding = viewCellPadding,
                Children =
                {
                    photo,
                    new Label
                    {
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        VerticalOptions = LayoutOptions.Center,
                        Text = description
                    }
                }
            };
        }
    }
