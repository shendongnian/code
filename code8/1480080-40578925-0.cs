    public static Array readCVS(string absolutePath)
    {
        string[,] temperatureMatrix = new string[384, 288];
        string value;
        using (TextReader fileReader = File.OpenText(absolutePath))
        {
            var csv = new CsvReader(fileReader);
            csv.Configuration.HasHeaderRecord = false;
            int y = 0;
            while (csv.Read())
            {
                for (int x = 0; csv.TryGetField<string>(x, out value); x++)
                    temperatureMatrix[y, x] = value;
                y = y + 1;
            }
            return temperatureMatrix;
        }
    }
