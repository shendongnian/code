    var dt = new DataTable("Rows");
    string data = "a,b,c\r\n1,2,3\r\n4,5,6";
    var stream = GenerateStreamFromString(data); // http://stackoverflow.com/questions/1879395/how-to-generate-a-stream-from-a-string
    using (var reader = new StreamReader(stream))
    {
        reader.ReadLine()?.Split(',').ToList().ForEach(h => dt.Columns.Add(h));
        while (!reader.EndOfStream)
        {
            dt.Rows.Add(reader.ReadLine()?.Split(',').ToArray());
        }
    }
    foreach (DataColumn dataColumn in dt.Columns)
    {
        Console.Write($"{dataColumn.ColumnName} ");
    }
    Console.WriteLine();
    
    foreach (DataRow dataRow in dt.Rows)
    {
        Console.Write("Row: ");
        foreach (var item in dataRow.ItemArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
