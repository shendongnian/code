    // type to hold the result
    public class SalariesPerDepartment
    {
         public string DepartmentName { get;set; }
         public decimal? TotalSalary { get; set; }
    }
                         // use type here
    public IEnumarable<SalariesPerDepartment> GetEmp()
    {
        return (from de in db.Dept_Emp
                 group de by de.DeprtmentName into g
                 select new SalariesPerDepartment // instantiate that type
                 {
                     DeprtmentName = g.Key,
                     TotalSalary = g.Sum(x => x.Sal)
                 });
    }
