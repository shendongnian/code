        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var mediaData = (MediaData)e.Parameter;
            newMedia.SetSource(mediaData.stream, mediaData.file.ContentType);
            newMedia.Play();
        }
