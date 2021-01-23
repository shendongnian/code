    class Program
    {
        static void Main(string[] args)
        {
            var processes = new List<Process>();
    
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
    
            var myFirstDate = new Process() { StartDate = new DateTime(year, month, 1), EndDate = new DateTime(year, month, 22) };
            processes.Add(myFirstDate);
            processes.Add(new Process() { StartDate = new DateTime(year, month, 14), EndDate = new DateTime(year, month, 23) });
            processes.Add(new Process() { StartDate = new DateTime(year, month, 19), EndDate = new DateTime(year, month, 31) });
            processes.Add(new Process() { StartDate = new DateTime(year, month, 27), EndDate = new DateTime(year, month, 12) });
            var myLastDate = new Process() { StartDate = new DateTime(year, month, 30), EndDate = new DateTime(year, month, 2) };
            processes.Add(myLastDate);
                
            var max = myLastDate.EndDate;
            var min = myFirstDate.StartDate;
    
        }
