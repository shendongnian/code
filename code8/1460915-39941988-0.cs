    var but = new Button();
    but.Content = "Hello";
    var popup = new Popup();
    popup.Child = but;
    popup.IsOpen = true;
    popup.Visibility = Visibility.Collapsed;
    but.Loaded += (s, e) =>
    {
        System.Diagnostics.Debug.WriteLine(but.RenderSize);
        popup.IsOpen = false;
    };
