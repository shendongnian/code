    ZXing.IBarcodeWriter writer = new ZXing.BarcodeWriter
    {
        Format = ZXing.BarcodeFormat.QR_CODE,//Mentioning type of bar code generation
        Options = new ZXing.Common.EncodingOptions
        {
            Height = 300,
            Width = 300
        },
        Renderer = new ZXing.Rendering.PixelDataRenderer() { Foreground = Windows.UI.Colors.Black }//Adding color QR code
    };
    var result = writer.Write("http://www.bsubramanyamraju.blogspot.com ");
    var wb = result.ToBitmap() as Windows.UI.Xaml.Media.Imaging.WriteableBitmap;
    //Displaying QRCode Image
    QrCodeImg.Source = wb;
