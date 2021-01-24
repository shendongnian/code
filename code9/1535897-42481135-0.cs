     [DllImport("addborders.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int main(IntPtr pointer, uint height,uint width);
     unsafe
            {
                fixed (byte* p = ImageToByte(img))
                {
                    var pct = (IntPtr) p;
                     x = main(pct, (uint)img.Height, (uint)img.Width);
                    
                }
                textBox1.Text = x.ToString();
                
     public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
