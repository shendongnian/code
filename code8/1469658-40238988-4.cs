    public class EmployeeCount
    {
        public string Employee {get; set;}
        public int Count {get; set;}
    }
    List<EmployeeCount> result = db.View_VisitorsForm
                   .Where(item => item.VisitingDate >= beginDate && item.VisitingDate < endDate)
                   .GroupBy(G => G.Employee)
                   .Select(e =>new EmployeeCount
                   {
                       employee = e.Key,
                       count = e.Count()
                   }).ToList();
    //Now add the result to the object you are passing to the View
