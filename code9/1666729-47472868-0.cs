        class Program
        {
            static void Main(string[] args)
            {
                var query = EAN_Budget_Meetdata_Factuur.factuurs
                        .Where(x => (x.eid == 1) && (x.bron == "B") && (x.date >= new DateTime(2016, 11, 1)) && (x.date <= new DateTime(2017, 1, 1)))
                        .Select(x => new { eid = x.eid, bron = x.bron, date = x.date })
                        .ToList();
            }
        }
        public class EAN_Budget_Meetdata_Factuur
        {
            public static List<EAN_Budget_Meetdata_Factuur> factuurs = new List<EAN_Budget_Meetdata_Factuur>();
            public int eid { get; set; }
            public string bron { get; set; }
            public DateTime date { get; set; }
        }
