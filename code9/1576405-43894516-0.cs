           static void Main(string[] args)
            {
                const int ROWS_PER_PAGE = 30;
                const int COLUMNS_PER_PAGE = 3;
                List<dynaTable> ldt = new List<dynaTable>();
                var results = ldt.OrderBy(x => x.name).Select((x, i) => new { person = x, index = i })
                    .GroupBy(x => (int)x.index / (ROWS_PER_PAGE * COLUMNS_PER_PAGE))
                    .Select(x => x.GroupBy(y => (int)((y.index % (ROWS_PER_PAGE * COLUMNS_PER_PAGE)) / ROWS_PER_PAGE)).Select(z => new { column1 = z.FirstOrDefault().person.name, column2 = z.Skip(1).FirstOrDefault().person.name, column3 = z.LastOrDefault().person.name }))
                    .SelectMany(x => x);
            }
        }
        public class dynaTable
        {
            public string name { get; set; }
        }
