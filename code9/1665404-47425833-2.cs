        private async void PivotItem_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ContentDialogResult result = await contentDialogForPwd.ShowAsync();
            if(result == ContentDialogResult.Primary)
            {
                //To do something when clicking Primary button
            }
            else if (result == ContentDialogResult.Secondary)
            {
                //To do something when clicking Secondary button
            }     
        }
