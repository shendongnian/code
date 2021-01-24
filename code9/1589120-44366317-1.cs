    using System.Collections.ObjectModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication57
    {
        class Program
        {
            static void Main(string[] args)
            {
                int employeeId = 113;
                List<E_JOURNAL> employee = E_JOURNAL.journals.Where(x => x.JOURNALID == employeeId).ToList();
                var results = (from j in employee
                               join s in E_ABSENCE.absenses on j.JOURNALID equals s.JOURNALID
                               orderby s.ABSENCEHISTORYID descending
                               select new {
                                   startDate = s.STARTDATE,
                                   reason = s.REASON,
                                    description = E_STATUS.statuses.Where(x => x.CURRENTITEMSTATUSID == j.CURRENTITEMSTATUSID).Select(x => x.DESCRIPTION).FirstOrDefault()
                               }).FirstOrDefault();
            }
            
        }
        public class E_JOURNAL
        {
            public static List<E_JOURNAL> journals = new List<E_JOURNAL>();
     
            public int JOURNALID { get; set; }
            public int ITEMNATUREID { get; set; }
            public int EMPLOYEEID { get; set; }
            public int CURRENTITEMSTATUSID { get; set; }
        }
        public class E_STATUS
        {
            public static List<E_STATUS > statuses = new List<E_STATUS>();
            public string DESCRIPTION { get; set; }
            public int CURRENTITEMSTATUSID { get; set; }
        }
        public class E_ABSENCE
        {
            public static List<E_ABSENCE> absenses = new List<E_ABSENCE>();
            public int JOURNALID { get; set; }
            public DateTime STARTDATE { get; set; }
            public string REASON { get; set; }
            public int ABSENCEHISTORYID { get; set; }
        }
        public class E_NATURE
        {
            public static List<E_NATURE> natures = new List<E_NATURE>();
            public int ITEMNATUREID { get; set; }
        }
    }
