    var csv = new StringBuilder();
    csv.AppendLine("Date,Pass"); // Header, skip if it is not needed
    var myQueriedList = ObserveData.Where(p => p.Pass == true);
    foreach (var value in myQueriedList )
    {
        //comma deliminated csv
        csv.AppendFormat("{0},{1}", value.Date.ToString(dateFormatString, CultureInfo.InvariantCulture), value.Pass.ToString().ToUpper()).AppendLine();
    }
    File.WriteAllText(filePath, csv.ToString());
