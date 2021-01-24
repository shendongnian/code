    // start
    System.Drawing.ImageAnimator.Animate(yourImage, OnFrameChanged);
    // stop
    System.Drawing.ImageAnimator.StopAnimate(yourImage, OnFrameChanged);
    private void OnFrameChanged(object sender, EventArgs args)
    {
    }
