    var firstLine = objReadFile.ReadLine(); // pop off the header line
    objWriteValidFile.WriteLine(firstLine);
    objWriteInValidFile.WriteLine(firstLine);
    while ((strLineData = objReadFile.ReadLine()) != null)
    //&& objReadFile.Peek() != -1)
    {       /*************************/
        //This first if statement bypasses the first line.
        //if (isFirst)
            //{
            //   isFirst = false;
            //          continue;
            //}
            /*************************/
        var parts = strLineData.Split(','); // assuming that ',' is your delimiter character
        if (parts.Length >= 2 && IsValid(parts[2]))
        {
            // write to valid file
        }
        else
        {
             // write to invalid file
    ...
