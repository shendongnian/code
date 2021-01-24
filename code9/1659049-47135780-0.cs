    foreach (string subfolder in Directory.GetDirectories(path))
    {
        Button btnSubfolder = new Button();
        btnSubfolder.Name = "btnsubfolder" + column.ToString();
        btnSubfolder.Content = subfolder.Substring(subfolder.LastIndexOf("\\") + 1);
        btnSubfolder.Margin = new Thickness(15, 15, 10, 0);
        btnSubfolder.Width = 200;
        btnSubfolder.Height = 50;
        btnSubfolder.HorizontalAlignment = HorizontalAlignment.Left;
        btnSubfolder.SetValue(Grid.ColumnProperty, column);
        grdsbFolders.Children.Add(btnSubfolder);
        grdsbFolders.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        grdsbFolders.Arrange(new Rect());
        var location = btnSubfolder.TranslatePoint(new Point(0, 0), grdsbFolders);
    }
