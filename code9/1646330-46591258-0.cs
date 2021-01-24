    private void Button_Click(object sender, RoutedEventArgs e)
    {
          Storyboard sb = Resources["closingAnimation"] as Storyboard;
          sb.Begin(this);
    }
    private void storyboardComplete(object sender, EventArgs e)
    {
       this.Close();
    }
