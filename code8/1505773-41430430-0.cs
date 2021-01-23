    class Log
    {
        public int DoneByEmpId { get; set; }
        public string DoneByEmpName { get; set; }
       
      }
    public class Class1
    {
        static void Range()
        {
            var array = new List<Log>() {new Log() {DoneByEmpId = 1,DoneByEmpName = "Jon"},
                new Log() { DoneByEmpId = 1, DoneByEmpName = "Jon" } ,
                new Log() { DoneByEmpId = 2, DoneByEmpName = "Max" },
                new Log() { DoneByEmpId = 2, DoneByEmpName = "Max" },
                new Log() { DoneByEmpId = 3, DoneByEmpName = "Peter" }};
            var ordered =
                array.GroupBy(x => x.DoneByEmpId).ToList().Select(x => x.FirstOrDefault()).OrderBy(x => x.DoneByEmpName);
            foreach (var item in ordered)
            {
                Console.WriteLine(item.DoneByEmpName);
            }
        }
    }
