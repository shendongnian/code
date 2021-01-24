    public class Program
    {
        [DelimitedRecord(",")] // you need to specify some delimiter, even if you change it later...
        public class Record
        {
            public string Id;
            public string Name;
        }
        static void Main(string[] args)
        {
            var engine = new FileHelperAsyncEngine<Record>();
            var options = engine.Options as DelimitedRecordOptions;
            options.Delimiter = "|"; // change the delimiter to vertical bar
            // test
            string src = "abc|JohnDoe";
            using (engine.BeginReadString(src))
            {
                var enumerator = (engine as IEnumerable<Record>).GetEnumerator();
                enumerator.MoveNext();
                Assert.AreEqual("abc", enumerator.Current.Id);
                Assert.AreEqual("JohnDoe", enumerator.Current.Name);
            }
            Console.ReadKey();
        }
    }
