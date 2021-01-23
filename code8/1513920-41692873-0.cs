    private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
          if (VoteListBoxItem.IsSelected) { ViewFrame.Navigate(typeof(VotePage)); }
          else if (AppDetailsListBoxItem.IsSelected) { ViewFrame.Navigate(typeof(AppDetailsPage)); }
    }
