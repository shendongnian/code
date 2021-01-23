    public ScalablePictureBox()
    {
        //some code ...
        this.pictureTracker.ScrollPictureEvent += new PictureTracker.ScrollPictureEventHandler(this.scalablePictureBoxImp.OnScrollPictureEvent);
        this.pictureTracker.PictureTrackerClosed += new PictureTracker.PictureTrackerClosedHandler(this.pictureTracker_PictureTrackerClosed);
        //Enter the line below to hook on event
         this.scalablePictureBoxImp.ZoomRateChangedEvent += ScalablePictureBoxImp_ZoomRateChangedEvent;
    }
