    public class ImageDisplayPage : ContentPage
        {
            public ImageDisplayPage()
            {
                Content = new ScrollView
                {
                    Content = new StackLayout()
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children =
                        {
                            new Image
                            {
                                IsVisible = true,
                                Aspect = Aspect.AspectFit,
                                Source = "a.png"
                            }
                        }
                    }
                };
            }
        }
