    var sw = new Stopwatch();
    sw.Start();
    using(var csv = new CsvReader(new StreamReader(@"csv-test.txt")))
    {
        csv.Configuration.Delimiter=" "; // space
        var sb = new StringBuilder();
        while (csv.Read())
        {
            var stringField = csv.GetField<string>("Location,"); // the comma is relevant
            // or use sb.AppendFormat("{0}\n", DoSomething(stringField));
            sb.AppendLine(stringField);
        }
        txtOutput.Text = sb.ToString();
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
