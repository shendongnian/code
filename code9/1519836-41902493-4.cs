    var sp = new StackPanel { Name = "SP3", Orientation = Orientation.Horizontal, Visibility = Visibility.Collapsed };
    sp.Children.Add(new TextBlock { Text = "3-1" });
    var txt = new TextBlock() { Text = "3-2" };
    txt.KeyDown += showNextLine;
    sp.Children.Add(txt);
    root.Children.Add(sp);
