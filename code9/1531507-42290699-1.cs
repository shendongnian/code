    [assembly: Xamarin.Forms.Dependency(typeof(OrientationService))]
    namespace Orientation
    {
        public class OrientationService: IOrientationService
        {
            public void Landscape()
            {
                ((Activity)Forms.Context).RequestedOrientation = ScreenOrientation.Landscape;
            }
    
            public void portrait()
            {
                ((Activity)Forms.Context).RequestedOrientation = ScreenOrientation.Portrait;
            }
        }
    }
