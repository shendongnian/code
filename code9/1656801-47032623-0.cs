    public static void FormatFile(String pathToFile)
    {
        string[] lines = File.ReadAllLines(pathToFile);
        using (FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            foreach( String line in lines)
            {
                if (String.IsNullOrWhiteSpace(line))
                    continue;
                String[] parts = line.Split(' ');
                for (int i = 0; i < parts.Length; i++)
                {
                    String part = parts[i].Trim();
                    if (!String.IsNullOrWhiteSpace(part))
                    {
                        sw.WriteLine(part);
                    }
                    else //if( ... )
                    {
                        sw.WriteLine("-");
                    }
                    //else if( ...)
                    //{
                    //    sw.WriteLine("KPC1");
                    //}
                    //else
                    //{
                    //
                    //}
                }   
            }
            sw.Flush(); 
        }
    }
