    using (var strInp = File.Open(inputFileName, FileMode.Open))
    using (var strOtp = File.Open(outputFileName, FileMode.Create))
    using (var reader = new StreamReader(strInp))
    using (var writer = new StreamWriter(strOtp))
    {
        var skipNext = false;
        var line = (string) null;
        while (reader.Peek() >= 0)
        {
            line = reader.ReadLine();
            if (line == "line 3")
            {
                skipNext = true;
            }
            else
            {
                if (skipNext)
                    skipNext = false;
                else
                    writer.WriteLine(line);
            }
        }
    }
