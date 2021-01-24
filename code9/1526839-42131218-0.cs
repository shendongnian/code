    bool open = true;
        private void MenuItem_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            ((MenuItem)sender).IsSubmenuOpen = open;
            open = true;
        }
        private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            open = false;
        }
