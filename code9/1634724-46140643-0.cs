        bool BrowserIsLoaded = false;
        private void Browser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if(BrowserIsLoaded)
                e.Cancel = true;
        }
        private void Browser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            BrowserIsLoaded = true;
        }
        
        private void Browser_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (BrowserIsLoaded)
                e.Handled = true;
        }
      
