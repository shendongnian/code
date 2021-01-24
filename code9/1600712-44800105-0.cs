    public class MyClass { public string Data1{get;set;} ...}
    using(var reader=File.OpenText(csvPath))
    {
        var csv = new CsvReader( textReader );
        csv.Configuration.Delimiter = "|";
        var records = csv.GetRecords<MyClass>().ToList();
        dgv1.DataSource=records;
    }
