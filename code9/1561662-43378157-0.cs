                byte BImageSource = ReadFully(file.GetStream());
                var bytes = new byte[file.GetStream().Length]; //file is from the plugin and contains your image
                file.GetStream().Position = 0;
                file.GetStream().Read(bytes, 0, (int)file.GetStream().Length);
                BImageSource = ReadFully(file.GetStream()); //BImageSource is your resource in bytes
        byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
