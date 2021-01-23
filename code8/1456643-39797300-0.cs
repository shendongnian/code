            FileStream fs = File.OpenRead(@"C:\YourFilePath");
            BinaryReader br = new BinaryReader(fs);
            string preamble = br.ReadBytes(4).ToString();
            string msgType = br.ReadByte().ToString();
            string msgLen = br.ReadBytes(3).ToString();
            string testID = br.ReadBytes(4).ToString();
