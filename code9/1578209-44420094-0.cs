    private void button1_Click(object sender, RoutedEventArgs e)
    {
        //Hides Current Button
        button1.Visibility = Visibility.Collapsed;
       
        //Checks and Shows Button 2
        if (button2.Visibility == Visibility.Collapsed)
        {
            button2.Visibility = Visibility.Visible;
        }
    }    
    private void button2_Click(object sender, RoutedEventArgs e)
    {
        //Hides Current Button
        button2.Visibility = Visibility.Collapsed;
       
        //Checks and Shows Button 1
        if (button1.Visibility == Visibility.Collapsed)
        {
            button1.Visibility = Visibility.Visible;
        }
    }
