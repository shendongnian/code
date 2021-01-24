    private void button1_Click(object sender, RoutedEventArgs e)
    {
        var newLine = new Line
        {
           Stroke = redBrush,
           StrokeThickness = 4,
           X1 = 237,
           Y1 = 382,
           X2 = 288,
           Y2 = 409
        };
        MainGrid.Children.Add(newLine);
    }
