     void OpenContextMenu(object sender, MouseButtonEventArgs e)
     {
         if (e.ChangedButton == MouseButton.Left)
         {
             FrameworkElement Sender = sender as FrameworkElement;
             Sender.ContextMenu.PlacementTarget = Sender;
             Sender.ContextMenu.IsOpen = true;
         }
         e.Handled = true;
     }
