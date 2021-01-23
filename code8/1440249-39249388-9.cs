    private void onLoadComplete(Object sender, AsyncCompletedEventArgs e)
    {
        PictureBox pic = sender as PictureBox;
        // Don't forget to check if the image has been really loaded,
        // this event fires also in case of errors.
        if (e.Error == null && !e.Cancelled)
        {
            pic.Tag = "1";
            Console.WriteLine("Image loaded");
        }
        else
        {
            pic.Tag = e.Error.Message;
            Console.WriteLine("Cancelled:" + e.Error.Message);
        }
    }
