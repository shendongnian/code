    public class SnippingTool
    {
        private SnippingTool(Bitmap screenShot)
        {
            this.ScreenShot = screenShot;
        }
        private static SnippingTool instance;
        public static void SetScreenshot(Bitmap screenShot)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SnippingTool(screenShot);
            }
            else
            {
                // now your logic, is it allowed then overwrite the screenShot, otherwise:
                throw new ArgumentException("It's not allowed to change the screenShot for this SnippingTool", nameof(screenShot));
            }
        }
        public static SnippingTool GetInstance
        {
            get
            {
                if (instance == null)
                    throw new Exception("The SnippingTool needs a screenShot first, use first " + nameof(SetScreenshot));
                return instance;
            }
        }
        public Bitmap ScreenShot { get; }
        // ...
    }
