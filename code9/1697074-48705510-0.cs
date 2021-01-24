        public static float GetImageWidthFromPath(string imgAbsolutPath, int offset)
        {
            float width = 0;
            using (Bitmap b = new Bitmap(imgAbsolutPath))
            {
                width = b.Width - offset;
            }
            return width;
        }
