     private void btClear_Click(object sender, RoutedEventArgs e)
     {
        botAxis.Minimum = botAxis.InternalAxis.ActualMinimum;
        botAxis.Maximum = botAxis.InternalAxis.ActualMaximum;
        lefAxis.Minimum = lefAxis.InternalAxis.ActualMinimum;
        lefAxis.Maximum = lefAxis.InternalAxis.ActualMaximum; 
        ls.ItemsSource = null;
     }
