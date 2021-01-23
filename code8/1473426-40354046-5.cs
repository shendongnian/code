    var inputFileName = @"D:\test-input.txt";
    var outputFileName = Path.GetTempFileName();
    var search = "line 4";
    using (var strInp = File.Open(inputFileName, FileMode.Open))
    using (var strOtp = File.Open(outputFileName, FileMode.Create))
    using (var reader = new StreamReader(strInp))
    using (var writer = new StreamWriter(strOtp))
    {
        while (reader.Peek() >= 0)
        {
            var lineOdd = reader.ReadLine();
            var lineEven = (string)null;
            if (reader.Peek() >= 0)
                lineEven = reader.ReadLine();
            if(lineOdd != search && lineEven != search)
            {
                writer.WriteLine(lineOdd);
                if(lineEven != null)
                    writer.WriteLine(lineEven);
            }
        }    
    }
    // at this point, operation is sucessfull
    // rename temp file with original one
    File.Delete(inputFileName);
    File.Move(outputFileName, inputFileName);
