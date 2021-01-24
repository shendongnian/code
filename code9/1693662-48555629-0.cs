    string[] existingLines = File.ReadAllLines(filepath);    
    
    foreach (var i = 0; i < existingLines.Length; i++)
    {                       
        // retrieve row by index
        var row = existingLines[i];
        // split into array of columns
        var columns = row.Split(Text_Separator); 
        // update column
        columns[0] = "Test Data";
        // create row from array of columns
        var updatedRow = string.Join(Text_Separator, columns);
        // update row in array of rows
        existingLines[i] = updatedRow;
    }
    
    var newdata = existingLines;
