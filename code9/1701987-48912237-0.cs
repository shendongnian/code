    namespace System
    {
        namespace Data
        {
            namespace Entity
            {
                public class DbFunctions
                {
                    public static Data AddYears(DateTime submittedTime, int i)
                    {
                        return new Data();
                    }
                    public class Data
                    {
                        public int Value { get; set; }
                    }
                   
                }
            }
        }
    }
    namespace ConsoleApplication23
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                Context context = new Context();
                int dateToCompare = DateTime.Now.Year;
                var corffIdsPerMaf = context.Mafs.Select(m => new { id = m.CorffId, mafs = m}).ToList();
                var corffIdForMaf = context.Corffs
                      .Where(c => System.Data.Entity.DbFunctions.AddYears(c.CorffSubmittedDateTime, 1).Value > dateToCompare)
                      .OrderByDescending(c => c.CorffSubmittedDateTime).Select(c => new { id = c.Id, corff = c}).ToList();
                var intersectResult = from p in corffIdsPerMaf
                              join f in corffIdForMaf on p.id equals f.id
                              select new SelectedCorffData() { CorffId = p.id, ReportNumber = f.corff.ReportNumber, CorffSubmittedDateTime = f.corff.CorffSubmittedDateTime };
                Dictionary<string, SelectedCorffData> dataSelectedForDeletion = intersectResult.GroupBy(x => x.ReportNumber, y => y).ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
        public class Context
        {
            public List<cMafs> Mafs { get; set;}
            public List<cCorffs> Corffs { get; set;}
        }
        public class cMafs
        {
            public int CorffId { get; set; }
        }
        public class cCorffs
        {
            public DateTime CorffSubmittedDateTime { get; set; }
            public int Id { get; set; }
            public string ReportNumber { get; set; }
        }
        public class Test
        {
        }
        public class SelectedCorffData
        {
            public long CorffId { get; set; }
            public string ReportNumber { get; set; }
            public DateTime CorffSubmittedDateTime { get; set; }
        }
    }
