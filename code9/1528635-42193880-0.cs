    public class MyClass
    {
        public int ID { get; set; }
    }
    var records = csv.GetRecords<MyClass>().ToList();
    var filtered = records.Where(r => r.ID >= 10);
