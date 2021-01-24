        class Program
        {
            static void Main(string[] args)
            {
                Context context = new Context();
                List<int> listAffId = new List<int>() { 547 }
                var query = (from a in context.A
                             join b in context.B on a.B_ID equals b.B_ID
                             select new { a = a, b = b})
                             .Where(x => listAffId.Contains(x.a.A_ID))
                             .OrderByDescending(x => x.a.VALUE_DATE)
                             .GroupBy(x => x.a.A_ID)
                             .Select(x => new {
                                 affId = x.Key,
                                 status = x.FirstOrDefault().b.STATUS
                             }).ToList();
                             
     
            }
        }
        public class Context
        {
            public List<TableA> A { get; set; }
            public List<TableB> B { get; set; }
        }
        public class TableA
        {
            public int A_ID { get; set; }
            public int B_ID { get; set; }
            public DateTime VALUE_DATE { get; set; }
        }
        public class TableB
        {
            public int B_ID { get; set; }
            public string STATUS { get; set; }
        }
