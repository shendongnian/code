    private void Btn1Click(object sender, RoutedEventArgs e)
    {
        int widthGrowth = 50;
        int heightGrowth = 80;
        Button btn = sender as Button;
        Point oldMousePosition = Mouse.GetPosition(btn);
        Width += widthGrowth;
        Height += heightGrowth;
        Point newMousePosition = Mouse.GetPosition(btn);
        Left += newMousePosition.X - oldMousePosition.X;
        Top += newMousePosition.Y - oldMousePosition.Y;
    }
