    public static Android.Content.Context Context { get; private set; }
    
    public override View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
    {
    MainActivityContext = context;
    return base.OnCreateView(parent, name, context, attrs);
    }`
    
    Then, I wrote a service implemenatation in which I take a screen capture, by using the static Context of the MainActivity, like this :
    
    `public class SnapshotService : ISnapshotService
    {
    public void Capture()
    {
    var screenshotPath = 
    Android.OS.Environment.GetExternalStoragePublicDirectory("Pictures").AbsolutePath +
    Java.IO.File.Separator + 
    "screenshot.png";
    var rootView = ((Android.App.Activity)MainActivity.Context).Window.DecorView.RootView;
    
        using (var screenshot = Android.Graphics.Bitmap.CreateBitmap(
                rootView.Width, 
                rootView.Height, 
                Android.Graphics.Bitmap.Config.Argb8888))
        {
            var canvas = new Android.Graphics.Canvas(screenshot);
            rootView.Draw(canvas);
    
            using (var screenshotOutputStream = new System.IO.FileStream(
                        screenshotPath, 
                        System.IO.FileMode.Create))
            {
                screenshot.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 90, screenshotOutputStream);
                screenshotOutputStream.Flush();
                screenshotOutputStream.Close();
            }
        }
    }
    }`
