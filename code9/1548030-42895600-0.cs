        public Bitmap createViewBitmap(View v)
        {
            Bitmap bitmap = Bitmap.CreateBitmap(v.Width, v.Height,
                    Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(bitmap);
            v.Draw(canvas);
            return bitmap;
        }
