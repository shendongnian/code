    var valueLines1 = dataTable.AsEnumerable()
                                      .Select(row => string.Join(",", row.ItemArray));
    lines.AddRange(valueLines1);
    
    File.AppendAllLines(savingFileName, lines);
