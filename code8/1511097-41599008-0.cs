     byte[] result;
                using (Stream streambytes = await artworkfile.OpenStreamForReadAsync())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        streambytes.CopyTo(memoryStream);
                        result = memoryStream.ToArray();
                    }
                }
                ArtworkRawData = result; 
