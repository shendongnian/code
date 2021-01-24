    DataTemplate itemTemplate = new DataTemplate(() =>
                {
                    Label label = new Label()
                    {
                        Margin = new Thickness(45, 0, 0, 0),
                        HorizontalOptions = LayoutOptions.Start,
                        FontSize = (double)Xamarin.Forms.Application.Current.Resources["BodyFontSize"],
                        HeightRequest = 20
                    };
                    label.SetBinding(Label.TextProperty, "Name");
    
                    ViewCell templateCell = new ViewCell()
                    {
                        View = label
                    };
    
                    return templateCell;
                });
