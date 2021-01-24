    private void BackwardButton_Tapped(object sender, TappedRoutedEventArgs e)
    {
        if (FavoriteListBox.Items.Count > 1)
        {
            //move to the previous item
            _displayedFavoriteIndex--;
            if (_displayedFavoriteIndex < 0) // Change here
            {
                //we have reached the end of the list
                _displayedFavoriteIndex = listobj.Count - 1;
            }
            //show the item            
            DisplayTextBlock.Text = listobj[ _displayedFavoriteIndex ].AnswerName;
        }
    }
