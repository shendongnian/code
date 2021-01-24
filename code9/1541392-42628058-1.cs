                    Android.Net.Uri uri = Android.Net.Uri.FromFile(new Java.IO.File(filePath));
                    System.IO.Stream input = context.ContentResolver.OpenInputStream(uri);
                    //Use bitarray to use less memory                    
                    byte[] buffer = new byte[16 * 1024];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int read;
                        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }
                        pictByteArray = ms.ToArray();
                    }
                    input.Close();
                    //Get file information
                    BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
                    Bitmap bitmap = BitmapFactory.DecodeByteArray(pictByteArray, 0, pictByteArray.Length, options);
                    imagen.SetImageBitmap(bitmap);
