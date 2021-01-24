    var csvFile = new StringBuilder();  
    csvFile.AppendLine("Column 1,Column 2,Column 3");
    foreach (var row in data)
    {
        csvFile.AppendLine($"{row.Column1Value},{row.Column2Value}, row.Column3Value}");
    }
    File.WriteAllText(filePath, csvFile.ToString());
