    byte[] pidBytes = new byte[4]; // we stored int which is 4 bytes wide;
    using (FileStream fs = File.OpenRead("C:\SomeArbitrary\PathToFile.txt"))
    {
        while(fs.CanRead)
        {
            fs.Read(pidBytes, 0, sizeof(int));
            m_Processes.Add(new ExcelProcess(BitConverter.ToInt32(pidBytes, 0)));
            fs.ReadByte(); // CR - 0x0D
            fs.ReadByte(); // LF - 0x0A
        }
    }
