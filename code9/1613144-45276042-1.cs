    byte[] nl = new byte[2] { 0x0D, 0x0A }; // new line
    using (FileStream fs = File.Create("C:\SomeArbitrary\PathToFile.txt"))
    {
        foreach(ExcelProcess proc in m_Processes)
        {  
            byte[] b = BitConverter.GetBytes(int.Parse(proc.ToString()));
            fs.Write(b, 0, b.Length);
            fs.Write(nl, 0, nl.Length);
        }
    }
