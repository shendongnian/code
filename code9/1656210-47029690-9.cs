    public static byte[] ReadReallyAllBytes(string filename)
    {
        byte[] retValue = null;
        
        using (System.IO.FileStream fs = System.IO.File.OpenRead(filename))
        {
            byte[] buffer = new byte[System.Environment.SystemPageSize];
            List<byte> byteList = new List<byte>();
            int ct = 0;
            while ((ct = fs.Read(buffer, 0, buffer.Length)) > 0)
            {
                for (int i = 0; i < ct; ++i)
                {
                    byteList.Add(buffer[i]);
                }
            }
            
            buffer = null;
            retValue = byteList.ToArray();
            byteList.Clear();
            byteList = null;
        }
        
        return retValue;
    }
    
    
    public static List<string> GetCmdLineArgs(int pid)            
    {
        List<string> ls = new List<string>();                
            
        byte[] buffer = ReadReallyAllBytes($"/proc/{pid}/cmdline");
        int last = 0;
        
        for (int i = 0; i < buffer.Length; ++i)
        {
            if (buffer[i] == 0)
            {
                string arg = System.Text.Encoding.UTF8.GetString(buffer, last, i-last);
                last = i + 1;
                ls.Add(arg);
            } // End if (buffer[i] == 0)
            
        } // Next i 
        
        // System.Console.WriteLine(ls);
        return ls;
    }
