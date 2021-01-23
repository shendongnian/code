    public static List<String> ReadAllLines(String fileName)
    {
        using(System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read))
        {
            using(System.IO.StreamReader sr = new System.IO.StreamReader(fs))
            {
                List<String> lines = new List<String>();
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
                return lines;
            }
        }
    
