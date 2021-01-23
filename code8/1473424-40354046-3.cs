    var inputFileName = @"D:\test-input.txt";
    var outputFileName = Path.GetTempFileName();
    using (var strInp = File.Open(inputFileName, FileMode.Open))
    using (var strOtp = File.Open(outputFileName, FileMode.Create))
    using (var reader = new StreamReader(strInp))
    using (var writer = new StreamWriter(strOtp))
    {
        var prevLine = (string)null;
        var line = (string) null;
        while (reader.Peek() >= 0)
        {
            line = reader.ReadLine();
            if (line == "line 3")
            {
                line = null;
                prevLine = null;
            }
            else
            {
                if(prevLine != null)
                    writer.WriteLine(prevLine);
    
                prevLine = line;
            }
        }
    
        if (line != null)
        {
            writer.WriteLine(line);
        }
    }
    // at this point, operation is sucessfull
    // rename temp file with original one
    File.Delete(inputFileName);
    File.Move(outputFileName, inputFileName);
