    using System.Drawing;
    using System.Windows.Media.Imaging;
    class IconHelper
    {
        public static Bitmap PngFromIcon(Icon icon)
        {
            Bitmap png = null;
            using (var iconStream = new System.IO.MemoryStream())
            {
                icon.Save(iconStream);
                var decoder = new IconBitmapDecoder(iconStream,
                    BitmapCreateOptions.PreservePixelFormat,
                    BitmapCacheOption.None);
                using (var pngSteam = new System.IO.MemoryStream())
                {
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(decoder.Frames[0]);
                    encoder.Save(pngSteam);
                    png = (Bitmap)Bitmap.FromStream(pngSteam);
                }
            }
            return png;
        }
    }
