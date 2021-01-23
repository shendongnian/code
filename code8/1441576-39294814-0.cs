    // Executing on non UI Thread
    BitmapImage bitmapImage = SingletonSetting.GetInstance().Logo;
    bitmapImage.Freeze(); // Has to be done on same thread it was created on - maybe freeze it in the Singleton instead?
    
    Application.Current.Dispatcher.Invoke(() => {
        // Executing on UI Thread
        Image v = new Image() { Source = bitmapImage };
        currnetrow.Cells.Add(new TableCell(new BlockUIContainer(v)));
    });
