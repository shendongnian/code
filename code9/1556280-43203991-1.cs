            private bool canCloseHamburgerMenu = true;
            private void User_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
            {
                canCloseHamburgerMenu = false;
            }
    
            private void User_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
            {
                canCloseHamburgerMenu = true;
            }
    
            private void MyHamburgerMenu_IsOpenChanged(object sender, ChangedEventArgs<bool> e)
            {
                var hm = sender as HamburgerMenu;
                if ((hm.DisplayMode == SplitViewDisplayMode.CompactOverlay || hm.DisplayMode == SplitViewDisplayMode.Overlay) && e.NewValue == false)
                {
                    //hm.IsOpen = canCloseHamburgerMenu == false ? true : false;
                }
            }
