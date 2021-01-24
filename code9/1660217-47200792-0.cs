    private void ChallengeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
       if (e.SelectedItem == null)
         return;
       
        viewModel.IsVisible = !viewModel.IsVisible;
    }
