    Border panel = new Border();
    Grid.SetColumn(panel, 3);
    Grid.SetRow(panel, 3);
    StackPanel stack = new StackPanel();
    panel.Child = stack;
    Label hasta = new Label();
    hasta.Content = str_hasta;
    stack.Children.Add(hasta);
    Label hastalik = new Label();
    hastalik.Content = str_hastalik;
    stack.Children.Add(hastalik);
    grd_gunluk.Children.Add(panel);
    panel.MouseLeftButtonDown += (ss, ee) =>
    {
        string a = hasta.Content.ToString();
        string b = hastalik.Content.ToString();
    };
