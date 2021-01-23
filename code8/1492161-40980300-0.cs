    public enum TabContent { Home, Replies, Messages, Settings }
    public void OpenTab(TabContent content) {
        // Set Page title and navigate
        switch (content) {
            case TabContent.Home:
                tbPageTitle.Text = "Home";        
                InnerFrame.Navigate(typeof(HomePage));
                break;
            case TabContent.Replies:
                tbPageTitle.Text = "Replies";        
                InnerFrame.Navigate(typeof(RepliesPage));
                break;
            case TabContent.Messages:
                tbPageTitle.Text = "Messages";        
                InnerFrame.Navigate(typeof(MessagesPage));
                break;
            case TabContent.Settings:
                tbPageTitle.Text = "Settings";        
                InnerFrame.Navigate(typeof(SettingsPage));
                break;
        }
    }
