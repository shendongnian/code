    var sw = new Stopwatch();
    sw.Start();
    var csv = new CsvReader(new StreamReader(@"csv-test.txt"));
    csv.Configuration.Delimiter=" "; // space
    var sb = new StringBuilder();
    while (csv.Read())
    {
        var stringField = csv.GetField<string>("Location,"); // the comma is relevant
        sb.AppendLine(stringField);
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
