    public class AdminCell : ViewCell
    {
        public AdminCell()
        {
            Label lbl_binding = new Label()
            {
                TextColor = Color.FromRgb(30, 144, 255),
                FontSize = 16,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lbl_binding.SetBinding(Label.TextProperty, ".");
            StackLayout stkBottom = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(0),
            };
            stkBottom.Children.Add(lbl_binding);
            View = stkBottom;
        }
    }
