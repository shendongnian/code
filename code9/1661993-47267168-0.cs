    private async void KinectSensorFound_DepthFrameReady(
        object sender, DepthImageFrameReadyEventArgs e)
    {
       await Task.Run(
         () => 
         {
           using (DepthImageFrame DataDepthImageFrame = e.OpenDepthImageFrame())
           {
               UpdateUserDepthInfo(DataDepthImageFrame)
           }
       });
    }
