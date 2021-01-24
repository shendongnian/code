    public class ZoomOutPageTransformer : Java.Lang.Object, IPageTransformer
    {
        private static float MIN_SCALE = 0.85f;
        private static float MIN_ALPHA = 0.5f;
    
        public void TransformPage(View page, float position)
        {
            int pageWidth = page.Width;
            int pageHeight = page.Height;
    
            if (position < -1)
            {
                page.Alpha = 0;
            }
            else if (position <= 1)
            {
                float scaleFactor = Math.Max(MIN_SCALE, 1 - Math.Abs(position));
                float vertMargin = pageHeight * (1 - scaleFactor) / 2;
                float horzMargin = pageWidth * (1 - scaleFactor) / 2;
                if (position < 0)
                    page.TranslationX = (horzMargin - vertMargin) / 2;
                else
                    page.TranslationX = (vertMargin - horzMargin) / 2;
    
                //Scale the page down
                page.ScaleX = scaleFactor;
                page.ScaleY = scaleFactor;
    
                page.Alpha = (MIN_ALPHA + scaleFactor - MIN_SCALE) / (1 - MIN_SCALE) * (1 - MIN_ALPHA);
            }
            else
            {
                page.Alpha = 0;
            }
        }
    }
