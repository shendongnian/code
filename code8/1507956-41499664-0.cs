    private int _displayedFavoriteIndex = -1;
    
    private void ShowButton_Click(object sender, EventArgs e)
    {
        //move to the next item
        _displayedFavoriteIndex++;    
        if ( _displayedFavoriteIndex >= listobj.Count )
        {
            //we have reached the end of the list
            _displayedFavoriteIndex = 0;
        }
        //show the item
        DisplayTextBlock.Text = listobj[ _displayedFavoriteIndex ].AnswerName;
    }
