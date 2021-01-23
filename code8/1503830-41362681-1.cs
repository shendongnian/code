    private void contactGridItem_RightTapped(object sender, RightTappedRoutedEventArgs e)
    {         
        FrameworkElement senderElement = sender as FrameworkElement;
        // Now you can get the tapped Item from the DataContext and set is as selected
        contactGrid.SelectedItem = senderElement.DataContext;
        if (contactGrid.SelectedIndex >= 0)
        {    
            
            MenuFlyout menu = new MenuFlyout();
            MenuFlyoutItem item1 = new MenuFlyoutItem() { Text = "Edit Contact" };
            MenuFlyoutItem item2 = new MenuFlyoutItem() { Text = "Comfirm" };
            MenuFlyoutSubItem item2a = new MenuFlyoutSubItem() { Text = "Remove Contact" };
            item1.Click += new RoutedEventHandler(EditContactClicked);
            item2.Click += new RoutedEventHandler(RemoveContactClicked);
            item2a.Items.Add(item2);
            menu.Items.Add(item1);
            menu.Items.Add(item2a);
            menu.ShowAt(senderElement, e.GetPosition(contactGrid));
        }
    }
