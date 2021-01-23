            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            MagickReadSettings settings = new MagickReadSettings();
            settings.Density = new Density(300, 300);
            
            List<ImageModel> model = new List<ImageModel>();
            using (MagickImageCollection images = new MagickImageCollection())
            {
                images.Read(data,settings); // Read PDF file
                foreach (MagickImage image in images)
                {
                    MemoryStream convertedFile = new MemoryStream();
                    ImageModel innerModle = new ImageModel();
                    image.Write(convertedFile, MagickFormat.Png);
                    byte[] data2 = convertedFile.ToArray();
                    innerModle.Image = data2;
                    model.Add(innerModle);                     
               }                 
            }                         
            return View(model);
        }
