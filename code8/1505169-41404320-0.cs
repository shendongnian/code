    string barcodeValue = "1234567";
    Code39BarcodeDraw barcode = BarcodeDrawFactory.Code39WithChecksum;
    MemoryStream ms = new MemoryStream();
    var barcodePic = barcode.Draw(barcodeValue, 50);
    barcodePic.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
    return Content(ms, "image/gif");
