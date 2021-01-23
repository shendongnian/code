    using (IRandomAccessStream strm = await file.OpenReadAsync())
                    {
                        bi.SetSource(strm);
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
