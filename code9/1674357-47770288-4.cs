    using Xamarin.Forms;
    using UIKit;
    
    [assembly: Dependency(typeof (iOSBrightnessService))]
    public class iOSBrightnessService : IBrightnessService
    {
        public void SetBrightness(float brightness)
        {
            UIScreen.MainScreen.Brightness = brightness;
        }
    }
