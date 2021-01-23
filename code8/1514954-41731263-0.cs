    public static void Main()
    {
        using (StreamReader sr = new StreamReader(path))
        {
            string[] headers = null;
            string[] curLine;
            while ((curLine = sr.ReadLine().Split(',')) != null)
            {
                if (firstLine == null)
                {
                    headers = curLine;
                }
                else
                {
                    processLine(headers, curLine);
                }
            }
        }
    }
    public static void processLine(string[] headers, string[] line)
    {
        for (int i = 0; i < headers.Length)
        {
            string header = headers[i];
            string line = line[i];
            //Now you have individual header/line pairs that you can put into mongodb
        }
    }
