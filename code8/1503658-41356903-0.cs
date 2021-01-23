        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ToolTip t = new ToolTip();
            t.Content = DateTime.Now.ToString();
            t.IsOpen = true;
            t.PlacementTarget = txtError;
            t.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            txtError.ToolTip = t;
        }
