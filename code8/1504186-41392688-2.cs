    private void VideoGridView_ItemClick(object sender, ItemClickEventArgs e)
    {
        var vedio = e.ClickedItem as VideoItem;          
        var item = new MediaPlaybackItem(MediaSource.CreateFromUri(new Uri(vedio.videoUri))); 
        mediaPlayerElement.Source = item;
    }
