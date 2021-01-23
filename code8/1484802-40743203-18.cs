        private void photo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var currentItem = narrowFlipview.SelectedItem as WaterfallDataItem;
            currentItem.IsDataVisible = !currentItem.IsDataVisible;
            //IsOn = !IsOn;
            //if (!IsOn)
            //{
            //    descbox.Visibility = Visibility.Collapsed;
            //    detailBtn.Visibility = Visibility.Visible;
            //    hideBtn.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    descbox.Visibility = Visibility.Visible;
            //    detailBtn.Visibility = Visibility.Collapsed;
            //    hideBtn.Visibility = Visibility.Visible;
            //}
        }
        
        private void DetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentItem = narrowFlipview.SelectedItem as WaterfallDataItem;
            currentItem.IsDescriptionVisible = true;
        }
        private void HideBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentItem = narrowFlipview.SelectedItem as WaterfallDataItem;
            currentItem.IsDescriptionVisible = false;
        }
