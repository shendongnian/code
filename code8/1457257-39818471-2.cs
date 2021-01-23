    BitmapImage bi = new BitmapImage();
    byte[] image_array = null;
    int image_array_width = 0;
    int image_array_height = 0;
    using (Stream stream = await (response.Content.ReadAsStreamAsync()))
    { 
        using (IRandomAccessStream strm = stream.AsRandomAccessStream()) 
        {
                        bi.SetSourceAsync(strm);
                        strm.Seek(0);
                        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(strm);
                        
                        BitmapFrame bitmapFrame = await decoder.GetFrameAsync(0);
                        // Get the pixels
                        PixelDataProvider dataProvider =
                        await bitmapFrame.GetPixelDataAsync(BitmapPixelFormat.Bgra8,
                                                                BitmapAlphaMode.Premultiplied,
                                                                new BitmapTransform(),
                                                                ExifOrientationMode.RespectExifOrientation,
                                                                ColorManagementMode.ColorManageToSRgb);
                        image_array = dataProvider.DetachPixelData();
                        image_array_width = bi.PixelWidth;
                        image_array_height = bi.PixelHeight;      
        }
    }   
