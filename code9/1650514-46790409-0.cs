    [assembly: ExportRenderer(typeof(ManateeShoppingCart.CameraPreview), typeof(ManateeShoppingCart.Droid.ScanPageRenderer))]
    namespace ManateeShoppingCart.Droid
    {
        public class ScanPageRenderer : ViewRenderer, IScanSuccessCallback
        {
            Scanner scanner;
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
            {
                base.OnElementChanged(e);
                if (e.OldElement != null || Element == null)
                {
                    return;
                }
                scanner = new Scanner(Forms.Context);
                scanner.setInterfaceOrientation("All");
                scanner.closeScannerOnDecode = false;
                customDecoderInit();
                double screenHeight = App.Current.MainPage.Height > App.Current.MainPage.Width ? App.Current.MainPage.Height : App.Current.MainPage.Width;
                double screenWidth = App.Current.MainPage.Height < App.Current.MainPage.Width ? App.Current.MainPage.Height : App.Current.MainPage.Width; ;
                float preivewX = (float)((CameraPreview)Element).CameraPreviewX;
                float preivewY = (float)((CameraPreview)Element).CameraPreviewY;
                float previewWidth = (float)((CameraPreview)Element).CameraPreviewWidth;
                float previewHeight = (float)((CameraPreview)Element).CameraPreviewHeight;
                scanner.ScanInView(this, new RectangleF((float)(preivewX / screenWidth) * 100, (float)(preivewY / screenHeight) * 100, (float)(previewWidth / screenWidth) * 100, (float)(previewHeight / screenHeight) * 100));
            }
    
