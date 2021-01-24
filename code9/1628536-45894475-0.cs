    MemoryStream ms = new MemoryStream();
    Picture.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
    // Reposition the Memory stream to the beginning of the data
    ms.Seek (0, SeekOrigin.Begin);
    // Allocate the array
    byte[] pic_arr = new byte[ms.Length];
    // Read the bytes into the array
    ms.Read (pic_arr, 0, ms.Length);
