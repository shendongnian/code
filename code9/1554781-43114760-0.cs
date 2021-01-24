    public class FD
    {
        public string Name { get; set; }
    }
     static void Main()
        {
            List<FD> fdList1 = new List<FD>();
            fdList1.Add(new FD { Name = "a" });
            List<FD> fdList2 = new List<FD>();
            fdList2.Add(new FD { Name = "a" });
           IEnumerable<FD> fd = fdList1.Intersect<FD>(fdList2, new ComparerFd()).ToList();
        }
