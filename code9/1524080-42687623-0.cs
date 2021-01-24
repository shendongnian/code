    CudafyModule km = new CudafyTranslator.Cudafy();
    GPGPU gpu = new CudafyHost.getDevice(CudafyModes.Target, CudafyModes.DeviceId);
    gpu.LoadModule(km);
    var image = new Bitmap(width, height);
    image = (Bitmap)Image.FromFile(@"C:\temp\a.bmp", true);
    byte[] imageBytes = new byte[width * height * 4];
    using(MemoryStream ms = new MemoryStream())
    {
        image.Save(ms, format);
        imageBytes = ms.ToArray();
    }
    byte[] device_imageBytes = _gpu.CopyToDevice(imageBytes);
    
    byte r = 0;
    byte g = 0;
    byte b = 0;
    
    byte device_r = _gpu.Allocate<byte>(r);
    byte device_g = _gpu.Allocate<byte>(g);
    byte device_b = _gpu.Allocate<byte>(b);
    
    //Call this in a loop
    gpu.Launch(N, 1).GetPixel(x, y, device_imageBytes, device_r, device_g, device_b);
    
    ...
    
    [Cudafy]
    public static void GetPixel(GThread thread, int x, int y, byte[] imageBytes, byte blue, byte green, byte red)
    {
        int offset = x * BPP + y * stride;
        blue = imageBytes[offset++];
        green = imageBytes[offset++];
        red = imageBytes[offset];
        double R = red;
        double G = green * 255;
        double B = blue * 255 * 255;
        //double A = temp.A * 255 * 255 * 255;
        //double depthvalue = A + B + G + R;
    }
