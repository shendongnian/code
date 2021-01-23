         byte[] fileBytes = null;
         var imageFile = *Your storageFile*;
                    
                        mimetype = imageFile.ContentType;
                        filetype = imageFile.FileType;
                        using (IRandomAccessStreamWithContentType stream = await imageFile.OpenReadAsync())
                        {
                            fileBytes = new byte[stream.Size];
                            using (DataReader reader = new DataReader(stream))
                            {
                                await reader.LoadAsync((uint)stream.Size);
                                reader.ReadBytes(fileBytes);
                            }
                        }
                    string base64 = Convert.ToBase64String(fileBytes);
