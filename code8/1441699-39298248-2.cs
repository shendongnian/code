        /* Mock class */
        public class Accession
        {
            [Column("Accession")]
            public string AccessionField { get; set; }
            public string Requisition { get; set; }
        }
        /* Mock class */
        public class Billing
        {
            public string Accession { get; set; }
            public string DateOfBirth { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        /* Mock class */
        public class DataManager
        {
            public IEnumerable<Accession> Accessions { get; set; }
            public IEnumerable<Billing> BillingOrderEntries { get; set; }
        }
        public static void Main(string[] args)
        {
            /* Start: Generate fake data */
            DataManager DM = new DataManager();
            DM.Accessions = new List<Accession>() { new Accession { AccessionField = "a1", Requisition="r1" }, new Accession { AccessionField = "a2", Requisition = "r2" } };
            DM.BillingOrderEntries = new List<Billing>() { new Billing { Accession = "a1", DateOfBirth = "01-01-2016", FirstName = "first1", LastName="last1" }, new Billing { Accession = "a2", DateOfBirth = "02-02-2016", FirstName = "first2", LastName = "last2" } };
            /* End: Generate fake data */
            var query = from a in DM.Accessions
                        join boe in DM.BillingOrderEntries on a.AccessionField equals boe.Accession
                        orderby boe.LastName
                        select new {
                            boe.DateOfBirth,
                            boe.FirstName,
                            boe.LastName,
                            a.AccessionField,
                            a.Requisition
                        };
            var boel = query.ToList();
        }
