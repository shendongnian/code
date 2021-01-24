    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Report> reports = new List<Report>();
    
                Report[] report1 =
                {
                    new Report {Id = 10001, Date = null},
                    new Report {Id = 10001, Date = null},
                    new Report {Id = 10001, Date = Convert.ToDateTime("01/01/2017")}
                };
    
    
                Report[] report2 =
                {
                    new Report {Id = 10002, Date = null},
                    new Report {Id = 10002, Date = null},
                    new Report {Id = 10002, Date = Convert.ToDateTime("03/01/2017")}
                };
    
    
                Report[] report3 =
                {
                    new Report {Id = 10003, Date = null},
                    new Report {Id = 10003, Date = null},
                    new Report {Id = 10003, Date = Convert.ToDateTime("05/01/2017")}
                };
    
    
                Report[] report4 =
                {
                    new Report {Id = 10004, Date = null},
                    new Report {Id = 10004, Date = null},
                    new Report {Id = 10004, Date = Convert.ToDateTime("07/01/2017")}
                };
    
                reports.AddRange(report1);
                reports.AddRange(report2);
                reports.AddRange(report3);
                reports.AddRange(report4);
    
    
                var report5 = new List<Report>()
                {
                    new Report {Id = null, Date = Convert.ToDateTime("02/01/2017")},
                    new Report {Id = null, Date = Convert.ToDateTime("04/01/2017")},
                    new Report {Id = null, Date = Convert.ToDateTime("06/01/2017")},
                };
    
                reports.AddRange(report5);
    
    
                foreach (var report in reports.OrderByDescending(x => x, new ReportComparer()))
                {
                    Console.WriteLine("ID = " + report.Id + " " + "Date = " + report.Date);
                }
    
                Console.ReadKey();
            }
    
    
             class ReportComparer: IComparer<Report>
            {
                public int Compare(Report x, Report y)
                {
                    // write your ordering rules here
                    if (x.Date.HasValue && y.Date.HasValue)
                    {
                        return x.Date.Value.CompareTo(y.Date.Value);
                    }
                    return x.Id.Value.CompareTo(y.Id.Value);
                }
            }
    
            class Report
            {
                public int? Id { get; set; }
                public DateTime? Date { get; set; }
            }
        }
    }
