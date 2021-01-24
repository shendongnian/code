    List<Border> borders = new List<Border>()
    {
        borderRow1Column1,
        borderRow1Column2,
        etc.
    }
    
    foreach (var border in borders)
    {
        border.Background = new SolidColorBrush(gray);
        Task.Delay(50).Wait();
        border.Background = new SolidColorBrush(black);
        Task.Delay(50).Wait();
    }
