    private async void Search_Click(object sender, RoutedEventArgs e) {
        if (contextViewModel.Searching) {
            contextViewModel.Processing = true;
            //Already searching, revert to clear state
            contextViewModel.Searching = false;
            await ClearSearchAsync(contextViewModel.FlaggedPeople);
            contextViewModel.Processing = false;
        } else {
            contextViewModel.Processing = true;
            contextViewModel.Searching = true;
            await ExecuteSearchAsync(SearchText.Text, contextViewModel.FlaggedPeople, SensitivitySlider.Value / 100);
            contextViewModel.Processing = false;
        }
    }
