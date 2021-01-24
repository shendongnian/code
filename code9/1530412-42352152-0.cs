    Rectangle rect = new Rectangle();
    rect.Opacity = 0.3;
    rect.SetValue(Grid.RowProperty, r);
    rect.SetValue(Grid.ColumnSpanProperty, 7);
    rect.Fill = new SolidColorBrush(Colors.Azure);
    rect.Margin = new Thickness(2);
    MyTooltip mt = new MyTooltip(par);
    ToolTip t = new ToolTip();
    t.Content = mt;
    t.Style = Application.Current.Resources["LargeToolTipStyle"] as Style;
    
    rect.SetValue(ToolTipService.ToolTipProperty, t);
