    private void Button_Click(object sender, RoutedEventArgs e)
    {
          Storyboard sb = Resources["closingAnimation"] as Storyboard;
          sb.Completed += new EventHandler(storyboardComplete);
          sb.Begin(this);
    }
    private void storyboardComplete(object sender, EventArgs e)
    {
       this.Close();
    }
