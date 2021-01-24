    [assembly: Xamarin.Forms.Dependency(typeof(OrientationService))]
    namespace Orientation
    {
        public class OrientationService: IOrientationService
        {
            public void Landscape()
            {
                UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.LandscapeLeft), new NSString("orientation"));
            }
    
            public void Portrait()
            {
                UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.Portrait), new NSString("orientation"));
            }
        }
    }
