    using Xamarin.Forms;
    
    [assembly: Dependency(AndroidBrightnessService)]
    public class AndroidBrightnessService : IBrightnessService
    {
        public void SetBrightness(float brightness)
        {
            var window = CrossCurrentActivity.Current.Activity.Window;
            var attributesWindow = new WindowManagerLayoutParams();
    
            attributesWindow.CopyFrom (window.Attributes);
            attributesWindow.ScreenBrightness = brightness;
    
            Window.Attributes = attributesWindow;
        }
    }
