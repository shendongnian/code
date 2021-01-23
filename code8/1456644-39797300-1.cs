            FileStream fs = File.OpenRead(@"C:\YourFilePath");
            BinaryReader br = new BinaryReader(fs);
            string preamble = Encoding.Default.GetString(br.ReadBytes(4));
            string msgType = br.ReadByte().ToString();
            string msgLen = Encoding.Default.GetString(br.ReadBytes(3));
            string testID = Encoding.Default.GetString(br.ReadBytes(4));
