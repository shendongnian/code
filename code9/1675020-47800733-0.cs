    public class EmployeesData
    {
        public List<EmployeeSomethingA> EmployeeSomethingAs { get; private set; }
        public List<EmployeeSomethingB> EmployeeSomethingBs { get; private set; }
        public List<EmployeeSomethingC> EmployeeSomethingCs { get; private set; }
        //Single predicate alternative. 
        public IEnumerable<EmployeeBase> Where(Func<EmployeeBase, bool> selector)
        {
            return EmployeeSomethingAs.Where(selector)
                .Union(EmployeeSomethingBs.Where(selector))
                .Union(EmployeeSomethingCs.Where(selector));
        }
        //Typed alternative
        public SearchResult FindById(int id)
        {
            var a = EmployeeSomethingAs.Where(e => e.EmployeeID == id);
            var b = EmployeeSomethingBs.Where(e => e.EmployeeID == id);
            var c = EmployeeSomethingCs.Where(e => e.EmployeeID == id);
            return new SearchResult(a, b, c);
        }
    }
    public class SearchResult
    {
        public SearchResult(IEnumerable<EmployeeSomethingA> a, IEnumerable<EmployeeSomethingB> b, IEnumerable<EmployeeSomethingC> c)
        {
            As = a;
            Bs = b;
            Cs = c;
        }
        public IEnumerable<EmployeeSomethingA> As { get; private set; }
        public IEnumerable<EmployeeSomethingB> Bs { get; private set; }
        public IEnumerable<EmployeeSomethingC> Cs { get; private set; }
    }
    public class EmployeeSomethingA : EmployeeBase
    {
        
        public string SomethingA { get; set; }
    }
    public class EmployeeSomethingB : EmployeeBase
    {
        
        public string SomethingB { get; set; }
    }
    public class EmployeeSomethingC : EmployeeBase
    {        
        public string SomethingC { get; set; }
    }
    public class EmployeeBase
    {
        public int EmployeeID { get; set; }
    }
