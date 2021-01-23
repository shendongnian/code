                var url = HostingEnvironment.MapPath("~/Images/" + name);
                byte[] myByte = System.IO.File.ReadAllBytes(url);
               using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(myByte, 0, myByte.Length);
                    i = System.Drawing.Image.FromStream(ms);
                    System.Drawing.Image imageIn = i.GetThumbnailImage(100, 100,()=> false, IntPtr.Zero);
                    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    var storedUrl = "data:image;base64," + Convert.ToBase64String(ms.ToArray());
                    return storedUrl;
                }
