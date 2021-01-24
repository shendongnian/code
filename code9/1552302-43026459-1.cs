    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var subMenuItemToAdd = new RadMenuItem();
            subMenuItemToAdd.Header = "Sub Menu Item";
            var secondMenuItem = Menu.Items[1] as RadMenuItem;
            secondMenuItem.Items.Add(subMenuItemToAdd);
        }
