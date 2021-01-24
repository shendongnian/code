    new Thread(() =>
    {
        for (int i = 0; i < 50000; i++)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                Rectangle rectangle = new Rectangle()
                {
                    Fill = new SolidColorBrush(Colors.Gray),
                    Width = 200,
                    Height = 290,
                    Margin = new Thickness(5, 0, 5, 5)
                };
                Others.Children.Add(rectangle);
            }));
        }
    }).Start();
