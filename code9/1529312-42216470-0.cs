            string CodePath = Environment.CurrentDirectory + @"\Code.txt";
            List<string> Codes = File.ReadLines(CodePath).ToList();
            string CountryPath = Environment.CurrentDirectory + @"\Country.txt";
            List<string> Countries = File.ReadLines(CountryPath).ToList();
            string result = string.Empty;
            int length = Math.Min(Codes.Count, Countries.Count);
            for (int i = 0; i < length; i++)
            {
                result += "Code = " + Codes[i] + Environment.NewLine + "Country = " + Countries[i] + Environment.NewLine;
            }
            string OutPath = Environment.CurrentDirectory + @"\out.txt";
            File.WriteAllText(OutPath, result);
