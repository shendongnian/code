    private async Task core()
    { 
        // generate audio
        int i = 0;
        for (int n = 1; n < co; n++)
        {
            // generate video and upload to
            // youtube, this generates, but
            // when uploading to youtube this for
            // loop carries on when I want it to
            // upload to youtube first before carrying on
            await generatevideo(image, articlename);
        }
    }
    private async Task generateVideo(string images, String articlename)
    {
       //generate the video here, once done upload
       {code removed, this just generates a video, nothing important}
       // now upload (but I want it to finish before repeating the core() function
       try
            {
                await new UploadVideo().Run(articlename, file);
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    ThreadSafe(() =>
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            status.Text = e.Message;
                            status.ForeColor = System.Drawing.Color.Red;
                        });
                    });
                }
            }
    }
