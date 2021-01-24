        public class TimelineGroups
        {
            public string id { get; set; }
            public string content { get; set; }
            public string className { get; set; }
            public string orderBy { get; set; }
            public List<string> nestedGroups { get; set; }
        }
            List<TimelineGroups> eg = (
                from sw in db.ScheduleWorks
                where sw.EndDate > DateTime.Now
                where sw.Employee.Emp_Status == 1
                group (sw.EmployeeId.ToString() + "." + sw.CustomerId.ToString())
                by new {
                    id = sw.EmployeeId.ToString(),
                    EmpName = sw.Employee.Emp_Name,
                    EmpOrder = sw.Employee.EmpRole_ID.ToString()
                }
                into g
                select new TimelineGroups()
                {
                    id = g.Key.id,
                    // find the list of employee+client keys 
                    nestedGroups = g.ToList(),
                    content = g.Key.EmpName,
                    orderBy = g.Key.EmpOrder
                })
                .Take(1000)
                .ToList();
