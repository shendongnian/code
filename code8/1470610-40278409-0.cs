    private async void LoadButton_Click(object sender, EventArgs e)
    {
        ...
        // populate with sample data...
        for (int index = 0; index < 200; ++index)
        {
            ...
            ImageResult result = await GetThumbnailForRow(...);
        }
    }
    
    private async Task<ImageResult> GetThumbnailForRow(int rowIndex, int itemId)
    {
        ...
        await Task.Delay(TimeSpan.FromSeconds(2));
        return ...;
    }
