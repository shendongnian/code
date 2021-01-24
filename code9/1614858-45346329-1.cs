        public static List<dynamic> Parse(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
    
        for (int i = 0; i < lines.Length; i++)
        {
            string recordId = lines[i].Substring(0, 2);
            switch (recordId)
            {
                case "00":
    
                    return Parse00(lines[i]).ToList<dynamic>; //public static List<mainInfo> Parse00(string line);
    
                case "11":
    
                    return Parse11(lines[i]).ToList<dynamic>; //public static List<param> Parse11(string line);
    
              …  
              …
    
            }
        }
    }
