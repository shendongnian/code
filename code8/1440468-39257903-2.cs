        void OpenContextMenu(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DockPanel Sender = sender as DockPanel;
                if (Sender != null)
                {
                    Sender.ContextMenu.PlacementTarget = Sender;
                    Sender.ContextMenu.IsOpen = true;
                    Sender.ContextMenu.UpdateLayout();
                } 
            }
            if (e.ChangedButton == MouseButton.Right)
            {
                e.Handled = true;
            }
        }
