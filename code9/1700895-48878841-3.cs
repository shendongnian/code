    public class DirectBitmap : IDisposable
    {
       public DirectBitmap(int width, int height, PixelFormat pixelFormat = PixelFormat.Format32bppPArgb)
       {
          Width = width;
          Height = height;
          Bounds = new Rectangle(0, 0, Width, Height);
          Bits = new int[width * height];
          BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
          Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
    
          using (var g = Graphics.FromImage(Bitmap))
          {
             g.Clear(Color.White);
          }
       }
    
       public DirectBitmap(Bitmap source)
       {
          Width = source.Width;
          Height = source.Height;
          Bounds = new Rectangle(0, 0, Width, Height);
          Bits = new int[source.Width * source.Height];
          BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
          Stride = (int)GetStride(PixelFormat, Width);
    
          Bitmap = new Bitmap(source.Width, source.Height, Stride, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
    
          using (var g = Graphics.FromImage(Bitmap))
          {
             g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height));
          }
       }
       
       ...
