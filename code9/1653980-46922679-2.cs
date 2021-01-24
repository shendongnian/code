        public DeviceOrientations GetOrientation()
        {
            var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
            if(currentOrientation == UIInterfaceOrientation.LandscapeLeft)
            {
                return DeviceOrientations.LandscapeLeft;
            }else if(currentOrientation == UIInterfaceOrientation.LandscapeRight)
            {
                return DeviceOrientations.LandscapeRight;
            }
           
            return DeviceOrientations.Others;
        }
