        void OpenContextMenu(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                //FrameworkElement Sender = sender as FrameworkElement;
                DockPanel Sender = sender as DockPanel;
                if (Sender != null)
                {
                    Sender.ContextMenu.PlacementTarget = Sender;
                    Sender.ContextMenu.IsOpen = true;
                    Sender.ContextMenu.UpdateLayout();
                    e.Handled = true;
                } else
                {
                    Debug.WriteLine(sender.GetType().ToString());
                }
            }
        }
