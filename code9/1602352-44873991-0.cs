      private void MultiFrameReader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
      {
            MultiSourceFrame multiSourceFrame = e.FrameReference.AcquireFrame();
            if (multiSourceFrame == null)
            {
                return;
            }
            using (ColorFrame colorFrame = multiSourceFrame.ColorFrameReference.AcquireFrame())
            {
                if (colorFrame == null) return;
                    
                using (DepthFrame depthFrame = multiSourceFrame.DepthFrameReference.AcquireFrame())
                {
                    if (colorFrame == null) return;
                    using (KinectBuffer buffer = depthFrame.LockImageBuffer())
                    {
                        ColorSpacePoint[] colorspacePoints = new ColorSpacePoint[depthFrame.FrameDescription.Width * depthFrame.FrameDescription.Height];
                        kinectSensor.CoordinateMapper.MapDepthFrameToColorSpaceUsingIntPtr(buffer.UnderlyingBuffer, buffer.Size, colorspacePoints);
                        //A depth point that we want the corresponding color point
                        DepthSpacePoint depthPoint = new DepthSpacePoint() { X=250, Y=250};
                        //The corrseponding color point
                        ColorSpacePoint targetPoint = colorspacePoints[(int)(depthPoint.Y * depthFrame.FrameDescription.Height + depthPoint.X)];
                    }
                }
            }  
        }
