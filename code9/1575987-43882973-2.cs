    public static class MyOwnExtensions
    {
        private static readonly ConditionalWeakTable<Bitmap, ThirdPartyImage>
            WeakBitmapImageTable = new ConditionalWeakTable<Bitmap, ThirdPartyImage>();
        public static Bitmap ToBitmap(this ThirdPartyImage image)
        {
            Bitmap bitmap = new Bitmap(image.Width, image.Height, image.Stride, image.Format,
                image.Data);
            WeakBitmapImageTable.Add(bitmap, image);
            return bitmap;
        }
    }
