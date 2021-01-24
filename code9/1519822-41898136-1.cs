        private void TabItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var tabItem = sender as TabItem;
            if(tabItem != null)
            {
                MessageBox.Show(tabItem.Header.ToString());
            }
        }
