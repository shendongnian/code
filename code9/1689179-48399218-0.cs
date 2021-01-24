    public ZXingDefaultOverlay()
    {
    
    BindingContext = this;
    
                RowSpacing = 0;
    
                VerticalOptions = LayoutOptions.FillAndExpand;
                HorizontalOptions = LayoutOptions.FillAndExpand;
    
                RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
                RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
    
    ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
    
    Children.Add(new BoxView
                {
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.Transparent,
                    Opacity = 0.7,
                }, 0, 0);
    
                Children.Add(new BoxView
                {
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.Transparent,
                    Opacity = 0.7,
                }, 0, 2);
    StackLayout ImageLabelContainer = new StackLayout();
    
                Image imgBox = new Image();
                imgBox.Source = "scan_qr.png";
                imgBox.VerticalOptions = LayoutOptions.Fill;
                imgBox.HorizontalOptions = LayoutOptions.FillAndExpand;
                ImageLabelContainer.Children.Add(imgBox);
    
                Label lblSuccess = new Label();
                lblSuccess.Margin = new Thickness(0, 7, 0, 0);
                lblSuccess.HorizontalTextAlignment = TextAlignment.Center;
                lblSuccess.TextColor = Color.Green;
                lblSuccess.AutomationId = "zxingDefaultOverlay_BottomTextLabel";
                lblSuccess.SetBinding(Label.TextProperty, new Binding(nameof(BottomText)));
                ImageLabelContainer.Children.Add(lblSuccess);
    
                Children.Add(ImageLabelContainer, 0, 1);
    }
