    private void DoMyWork(CancellationToken cancellationToken)
    {
        // Do the same as in your DoThisAllTheTime
        // except that you regularly check cancellationToken.IsCancelRequested:
        while(!cancellationToken.IsCancelRequested)
        {
            // calculate the image to display
            var imageToDisplay = ...
            this.DisplayImage(imageToDisplay);
        }
    }
    void DisplayImage(Image imageToDisplay)
    {
        if (this.pictureBox1.InvokeRequired)
        {
            this.Invoke(new MethodInvoker( () => this.DisplayImage(imageToDisplay)));
        }
        else
        {
            this.PictureBox1.Image = imageToDisplay;
        }
    }
