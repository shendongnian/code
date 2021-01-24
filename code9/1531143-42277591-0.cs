    private async Task ClearComparePicture() {
        DiffrenceImage.Source = null;    
        LoadingComparisonResultLabel.Visibility = Visibility.Visible;
        ComparisonResultImageBox.Visibility = Visibility.Collapsed;
        await Task.Delay(2000);
        DiffrenceImage.Source = newBitmapImage;
        LoadingComparisonResultLabel.Visibility = Visibility.Collapsed;
        ComparisonResultImageBox.Visibility = Visibility.Visible;
    }
