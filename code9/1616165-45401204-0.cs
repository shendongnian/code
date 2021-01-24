           string filepath = "D:\\sample.csv";
           var lineCount = File.ReadAllLines(@"D:\\sample.csv").Length;
           int TotalLines = Int32.Parse(lineCount.ToString());
           StreamReader sr = new StreamReader(filepath);
           string line;
           List<string> lstSample = new List<string>();
           while ((line = sr.ReadLine()) != null)
           {
               lstSample = line.Split(',').ToList();
           }
