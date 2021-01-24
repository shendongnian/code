    public static List<string[]> readCSV(String filename)
    {
        List<string[]> result = new List<string[]>();
        try
        {
            string[] line = File.ReadAllLines(filename);
            foreach (string l in line)
            {
                string[] value= vrstica.Split(',');
                result.Add(value);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: '{0}'", e);
        }
        return result;
    }
