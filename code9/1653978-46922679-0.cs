    using UIKit;
    using Foundation;
    
    namespace DependencyServiceSample.iOS
    {
        public class DeviceOrientationImplementation : IDeviceOrientation
        {
            public DeviceOrientationImplementation(){ }
    
            public DeviceOrientations GetOrientation()
            {
                var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
                bool isPortrait = currentOrientation == UIInterfaceOrientation.Portrait
                    || currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;
    
                return isPortrait ? DeviceOrientations.Portrait: DeviceOrientations.Landscape;
            }
        }
    }
