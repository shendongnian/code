    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<ActivitySummary> SummaryList = new List<ActivitySummary>();
                SummaryList.Add(new ActivitySummary() { Name = "ATT", Marks = "200" });
                SummaryList.Add(new ActivitySummary() { Name = "CHARTER", Marks = "600" });
                int total = SummaryList.Select(x => int.Parse(x.Marks)).Sum();
                SummaryList.Add(new ActivitySummary() { Name = "TOTAL", Marks = total.ToString() });
            }
        }
        public class ActivitySummary
        {
            public string Name { get; set; }
            public string Marks { get; set; }
        }
    }
