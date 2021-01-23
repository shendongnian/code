    static Bgra32Pixel[] ConvertBytesToPixels(byte[] data)
    {
        if (data.Length % 4 != 0) throw new ArgumentOutOfRangeException("data", "Data length must be divisable by four.");
    
        int size = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Bgra32Pixel));
        Bgra32Pixel[] pixels = new Bgra32Pixel[data.Length / 4];
        for (int i = 0; i < pixels.Length; i++)
        {
            IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal(size);
            System.Runtime.InteropServices.Marshal.Copy(data, i * 4, ptr, size);
            pixels[i] = (Bgra32Pixel)System.Runtime.InteropServices.Marshal.PtrToStructure(ptr, typeof(Bgra32Pixel));
            System.Runtime.InteropServices.Marshal.FreeHGlobal(ptr);
        }
        return pixels;
    }
