    for (int i = 1; i < 20; i++)
    {
          Ellipse el = new Ellipse();
          el.Height = 200;
          el.Width = 200;
          el.StrokeThickness = 5;
          SolidColorBrush mySolidColorBrush = new SolidColorBrush();
          mySolidColorBrush.Color = Color.FromArgb(255, 255, 0, 0);
          el.Fill = mySolidColorBrush;
          ViewGrid.Items.Add(el);
    }
