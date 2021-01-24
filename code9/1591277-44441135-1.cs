    private void button_Click(object sender, RoutedEventArgs e)
    {
       if(Properties.Settings.Default.Color1 == "White")
       {
          Properties.Settings.Default.Color1 = "Black";
       }
       else
       {
          Properties.Settings.Default.Color1 = "White";
       }
    }
