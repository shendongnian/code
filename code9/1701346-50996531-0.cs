    public static class NibLoadingExtension
    {
        public static T LoadViewFromNib<T>(this T @null) where T : NSView
        {
            NSBundle.MainBundle.LoadNibNamed(typeof(T).Name, null, out var array);
            return NSArray.FromArray<NSObject>(array).OfType<T>().FirstOrDefault();
        }
    }
