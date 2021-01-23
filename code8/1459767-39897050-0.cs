    Color borderColor = (Color)ColorConverter.ConvertFromString(BorderColor);
    Color backgroundColor = (Color)ColorConverter.ConvertFromString(BackgroundColor);
    
    Border border = new Border();
    border.BorderThickness = new Thickness(BorderSize);
    border.CornerRadius = new CornerRadius(TopLeftCornerRadius, TopRightCornerRadius, BottomRightCornerRadius, BottomLeftCornerRadius);
    border.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(BorderColor));
    border.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(BackgroundColor));
    
    border.Width = Width;
    border.Height = Height;
    
    border.Margin = new Thickness(10);
    
    Viewbox viewBox = new Viewbox();
    viewBox.Stretch = Stretch.Uniform;
    viewBox.Child = border;
    
    previewcanvas.Children.Add(viewBox);
