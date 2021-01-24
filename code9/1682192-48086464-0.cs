    public static void ReadReplace()
    {
        string text = File.ReadAllText(@"C:\TestDirectory\Test.csv");
        using (StreamReader sr = new StreamReader(@"C:\TestDirectory\Test.csv"))
        {
            foreach(string test in File.ReadLines(@"C:\TestDirectory\Test.csv"))
            {
                String line;    
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string serviceId = parts[34].Trim('"');
                    string appendedServiceId = serviceId + "a";
   
                    text = text.Replace(serviceId, appendedServiceId);
    
                }
            }
        }
        File.WriteAllText(@"C:\TestDirectory\TestUpdated.csv", text);
    
    }
