    private void btn1_Click(object sender, RoutedEventArgs e)
    {
        Dock_MainPanel.Children.Clear();
        Dock_MainPanel.Visibility = Visibility.Visible;
        Sample1 usr1 = new Sample1();
        DockPanel.SetDock(usr1, Dock.Right);
        Dock_MainPanel.Children.Add(usr1);
    }
