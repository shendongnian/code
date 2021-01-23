            byte[] image_array = null;
            int image_array_width = 0;
            int image_array_height = 0;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(new Uri("http://www.example.com/logo.png", UriKind.RelativeOrAbsolute));
                    if (response != null && response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = await (response.Content.ReadAsStreamAsync()))
                        {
                            using (IRandomAccessStream strm = stream.AsRandomAccessStream())
                            {
                                strm.Seek(0);
                                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(strm);
                                BitmapFrame bitmapFrame = await decoder.GetFrameAsync(0);
                                // Get the pixels
                                var transform = new BitmapTransform { ScaledWidth = decoder.PixelWidth, ScaledHeight = decoder.PixelHeight };
                                PixelDataProvider dataProvider =
                                await bitmapFrame.GetPixelDataAsync(BitmapPixelFormat.Bgra8,
                                                                        BitmapAlphaMode.Straight,
                                                                        transform,
                                                                        ExifOrientationMode.RespectExifOrientation,
                                                                        ColorManagementMode.ColorManageToSRgb);
                                await strm.FlushAsync();
                                image_array = dataProvider.DetachPixelData();
                                image_array_width = (int)decoder.PixelWidth;
                                image_array_height = (int)decoder.PixelHeight;
                                }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
