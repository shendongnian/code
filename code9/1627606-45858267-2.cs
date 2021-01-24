    void GeneralProcess_Loaded(object sender, RoutedEventArgs e)
    {
        if (DesignerProperties.GetIsInDesignMode(this))
            return;
        var popup = new StationSelect();
        popup.Owner = Window.GetWindow(this);
        popup.ShowDialog();
    }
