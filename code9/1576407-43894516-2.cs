        class Program
        {
            static void Main(string[] args)
            {
                const int ROWS_PER_PAGE = 30;
                const int COLUMNS_PER_PAGE = 3;
                List<dynaTable> ldt = new List<dynaTable>();
                var results = ldt.OrderBy(x => x.name).Select((x, i) => new { person = x, index = i })
                    .GroupBy(x => (int)x.index / (ROWS_PER_PAGE * COLUMNS_PER_PAGE))
                    .Select(x => x.GroupBy(y => y.index % ROWS_PER_PAGE).Select(z => new { 
                         col1 = z == null ? "" : z.FirstOrDefault() == null ? "" : z.FirstOrDefault().person.name,
                         col2 = z == null ? "" : z.Skip(1).FirstOrDefault() == null ? "" : z.Skip(1).FirstOrDefault().person.name,
                         col3 = z == null ? "" : z.Skip(1).LastOrDefault() == null ? "" : z.LastOrDefault().person.name
                    }))
                    .SelectMany(x => x).ToList();
            }
        }
        public class dynaTable
        {
            public string name { get; set; }
        }
