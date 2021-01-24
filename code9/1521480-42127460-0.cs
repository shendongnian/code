    private void tbtnCash_Tapped(object sender, TappedRoutedEventArgs e)
    {
        Debug.WriteLine("Tap is fired!");
        e.Handled = true;
        tbtnCash.IsChecked = true;
        tbtnCard.IsChecked = false;
    }
    
    private void tbtnCard_Tapped(object sender, TappedRoutedEventArgs e)
    {
        e.Handled = true;
        tbtnCash.IsChecked = false;
        tbtnCard.IsChecked = true;
    }
    
    private void tbtnCash_Click(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine("Click is fired!");
        tbtnCash.IsChecked = true;
        tbtnCard.IsChecked = false;
    }
    
    private void tbtnCard_Click(object sender, RoutedEventArgs e)
    {
        tbtnCash.IsChecked = false;
        tbtnCard.IsChecked = true;
    }
