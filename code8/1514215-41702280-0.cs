         MouseEventArgs rato = e as MouseEventArgs;
         Bitmap b = ((Bitmap)originalmaster.Image);
         int x = rato.X * b.Width / originalmaster.ClientSize.Width;
         int y = rato.Y * b.Height / originalmaster.ClientSize.Height;
         Color c = b.GetPixel(x, y);
