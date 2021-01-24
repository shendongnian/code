        private BitmapDescriptor GetCustomBitmapDescriptor(string text)
        {
            using (Paint paint = new Paint(PaintFlags.AntiAlias))
            {
                using (Rect bounds = new Rect())
                {
                    using (Bitmap baseBitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.marker))
                    {
                        Bitmap resultBitmap = Bitmap.CreateBitmap(baseBitmap, 0, 0, baseBitmap.Width - 1, baseBitmap.Height - 1);
                        Paint p = new Paint();
                        ColorFilter filter = new PorterDuffColorFilter(Android.Graphics.Color.ParseColor(text), PorterDuff.Mode.SrcAtop);
                        p.SetColorFilter(filter);
                        Canvas canvas = new Canvas(resultBitmap);
                        canvas.DrawBitmap(resultBitmap, 0, 0, p);
                        Bitmap scaledImage = Bitmap.CreateScaledBitmap(resultBitmap, 94, 150, false);
                        BitmapDescriptor icon = BitmapDescriptorFactory.FromBitmap(scaledImage);
                        resultBitmap.Recycle(); 
                        return (icon);
                    }
                }
            }
        }
