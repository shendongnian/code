    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ToggleButton tb = (ToggleButton)sender;
        if (tb.IsChecked == true)
        {
            string name2 = tb.Name + "Q";
            TextBox tbox = FindName(name2) as TextBox;
            //  Check to see if tbox is null, do stuff with it
        }
    }
