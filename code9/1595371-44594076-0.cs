    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button s = sender as Button;
        System.Windows.Controls.Primitives.Popup popup = new System.Windows.Controls.Primitives.Popup();
        popup.AllowsTransparency = true;
        popup.Child = new myCustomView();
        //some stuff needed to recognise which button was pressed
        popup.PlacementTarget = s;
        popup.Placement = System.Windows.Controls.Primitives.PlacementMode.Top;
        popup.IsOpen = true;
        popup.StaysOpen = true;
    }
