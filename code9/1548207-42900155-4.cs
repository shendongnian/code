    public class mPreviewCallback : Java.Lang.Object, IPreviewCallback
    {
        public void OnPreviewFrame(byte[] data, Camera camera)
        {
            var paras = camera.GetParameters();
            var imageformat = paras.PreviewFormat;
            if (imageformat == Android.Graphics.ImageFormatType.Nv21)
            {
                Android.Graphics.YuvImage img = new Android.Graphics.YuvImage(data,
                    imageformat, paras.PreviewSize.Width, paras.PreviewSize.Height, null);
            }
        }
    }
