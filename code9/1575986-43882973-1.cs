    public static class MyOwnExtensions
    {
        private static ConditionalWeakTable<Bitmap, ThirdPartyImage>
            _weakBitmapImageTable = new ConditionalWeakTable<Bitmap, ThirdPartyImage>();
        public static Bitmap ToBitmap(this ThirdPartyImage image)
        {
            Bitmap bitmap = new Bitmap(image.Width, image.Height, image.Stride, image.Format,
                image.Data);
            _weakBitmapImageTable.Add(bitmap, image);
            return bitmap;
        }
    }
