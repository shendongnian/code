    public class TestClass
    {
        public int RowCount { get; set; }
    }
    var results = _context.ExecSQL<>("EXECUTE TestProcedure");
    foreach(var testClass in results)
    {
        Console.WriteLine(testClass.RowCount);
    }
