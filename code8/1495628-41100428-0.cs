    class Program
    {
        private static readonly string ConnectionString = "type=embedded;storesDirectory=brightstardb;storeName=anytest";
        static void Main(string[] args)
        {
            SetupStore();
            QueryStore();
        }
        private static void SetupStore()
        {
            if (!Directory.Exists("brightstardb"))
            {
                Directory.CreateDirectory("brightstardb");
                using (var context = new MyEntityContext(ConnectionString)
                )
                {
                    var doc1 = context.Documents.Create();
                    var doc2 = context.Documents.Create();
                    var doc3 = context.Documents.Create();
                    var p1 = context.Principles.Create();
                    p1.History = new List<string> {"Strings", "of", "Text"};
                    var p2 = context.Principles.Create();
                    p2.History = new List<string> {"Nothing", "To See Here", "Move Along"};
                    var p3 = context.Principles.Create();
                    p3.History = new List<string> { "Another", "Principle containing Text"};
                    doc1.Principles = new List<IPrinciple> {p1};
                    doc2.Principles = new List<IPrinciple> {p2};
                    doc3.Principles = new List<IPrinciple> {p3};
                    context.SaveChanges();
                }
            }
        }
        private static void QueryStore()
        {
            using (var context = new MyEntityContext(ConnectionString))
            {
                var principles = (from p in context.Principles where p.History.Any(h => h.Contains("Text")) select p).ToList();
                foreach (var p in principles)
                {
                    Console.WriteLine("Found principle: {0}", p.Id);
                }
            }
        }
    }
