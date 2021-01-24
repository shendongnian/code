    private void btn_Click(object sender, RoutedEventArgs e)
    {
        Button s = sender as Button;
        System.Windows.Controls.Primitives.Popup popup = new System.Windows.Controls.Primitives.Popup();
        popup.AllowsTransparency = true;
        popup.Child = new myCustomView();
        //some stuff needed to recognise which button was pressed
        popup.PlacementTarget = ic; //<-- "ic" is the name of the parent ItemsControl
        Point p = s.TranslatePoint(new Point(0, 0), ic);
        popup.VerticalOffset = p.Y; //adjust this value to fit your requirements
        popup.HorizontalOffset = p.X; //adjust this value to fit your requirements
        popup.IsOpen = true;
        popup.StaysOpen = true;
    }
