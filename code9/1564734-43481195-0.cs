    private async Task core()
    { 
        // generate audio
        int i = 0;
        for (int n = 1; n < co; n++)
        {
            await generatevideo(image, articlename);
        }
    }
    private async Task generateVideo(string images, String articlename)
        {
           //generate the video here,
           try
                {
                    var uploadVideo = new UploadVideo();
                    await uploadVideo.Run(articlename, file);
    
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
