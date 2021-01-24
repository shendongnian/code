        private void pnlTopMenu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
            if (e.ClickCount == 1)
            {
                // I manually close Popup control, so both Popup and stackpanel will be closed on mouse left button down double click
                this.MyPopup.IsOpen = false;
            }
            else if (e.ClickCount >= 2)
            {
                // Story board that starts and hide the stackpanel on double click.
                Storyboard sb = Resources["sbHideTopMenu"] as Storyboard;
                sb.Begin(pnlTopMenu);
            }
        }
