     AssetManager assets = this.Assets;
     using (Stream input = assets.Open("ca-bundle.crt"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    data = ms.ToArray();
                }
            }
