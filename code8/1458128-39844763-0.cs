        var fileStream = new FileStream(Directory.GetCurrentDirectory() + @"\DvDB.ADB", FileMode.Open, FileAccess.Read);
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.Contains(""+Model_Number))
                {
                    //Need to perform the processing here.
                    string[] lineArray = line.Split(' ').Skip(4).ToArray();
                    //Each word is assumed to be separated by a space character
                    //Array now contains the 5th to the last words from the line.
                }
            }
        }
