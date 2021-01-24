                    // Create byte array that contains a png file
                    byte[] imageData = magicImage.ToByteArray();
    
                    using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                    {
                        using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                        {
                            writer.WriteBytes(imageData);
                            await writer.StoreAsync();
                        }
    
                        await bitmapImage.SetSourceAsync(stream);
                    }
    
    
    return bitMapImage; // new BitMapImage() was scoped before all of this
