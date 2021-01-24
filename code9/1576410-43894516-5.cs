        class Program
        {
            static void Main(string[] args)
            {
                const int ROWS_PER_PAGE = 30;
                const int COLUMNS_PER_PAGE = 3;
                List<dynaTable> ldt = new List<dynaTable>();
                for(int i = 0; i < 84; i++)
                {
                    ldt.Add(new dynaTable() { name = Encoding.UTF8.GetString(new byte[] {(byte)(i + 0x20)})});
                }
                var results = ldt.OrderBy(x => x.name).Select((x, i) => new { person = x, index = i })
                    .GroupBy(x => (int)(x.index / (ROWS_PER_PAGE * COLUMNS_PER_PAGE)))
                    .Select(x => x.GroupBy(y => y.index % ROWS_PER_PAGE).Select(z => new {
                        col1 = z == null ? string.Empty : z.FirstOrDefault() == null ? string.Empty : z.FirstOrDefault().person.name,
                        col2 = z == null ? string.Empty : z.Skip(1).FirstOrDefault() == null ? string.Empty : z.Skip(1).FirstOrDefault().person.name,
                        col3 = z == null ? string.Empty : z.Skip(2).FirstOrDefault() == null ? string.Empty : z.Skip(2).FirstOrDefault().person.name,
                    }))
                    .SelectMany(x => x).ToList();
            }
        }
        public class dynaTable
        {
            public string name { get; set; }
        }
    }
