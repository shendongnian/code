    // A class for each intervall
    public class MyIntervall
    {
        public MyIntervall(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;
        }
    
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    
    public static void Main(params string[] args)
    {
        // Your data..
        List<MyIntervall> intervalls = new List<MyIntervall>()
        {
            new MyIntervall(new DateTime(2018, 1, 19, 10, 0, 0), new DateTime(2018, 1, 19, 12, 0, 0)),
            new MyIntervall(new DateTime(2018, 1, 19, 12, 0, 0), new DateTime(2018, 1, 19, 14, 0, 0)),
            new MyIntervall(new DateTime(2018, 1, 19, 14, 0, 0), new DateTime(2018, 1, 19, 16, 0, 0)),
            new MyIntervall(new DateTime(2018, 1, 19, 19, 0, 0), new DateTime(2018, 1, 19, 20, 0, 0)),
            new MyIntervall(new DateTime(2018, 1, 19, 16, 0, 0), new DateTime(2018, 1, 19, 17, 0, 0)),
            new MyIntervall(new DateTime(2018, 1, 19, 22, 0, 0), new DateTime(2018, 1, 19, 23, 0, 0))
        };
    
        MyIntervall lastIntervall = null;
        List<MyIntervall> mergedIntervalls = new List<MyIntervall>();
        // Loop through your list.
        foreach (MyIntervall currenIntervall in intervalls.OrderBy(o => o.Start))
        {
            if (lastIntervall == null)
            {
                // Start-condition
                lastIntervall = currenIntervall;
            }
            else if (lastIntervall.End == currenIntervall.Start)
            {
                // If the last intervall ends at the start of the next one, we merge them into one bigger intervall by moving the end.
                lastIntervall.End = currenIntervall.End;
            }
            else
            {
                // If end doesn't match the next start, we know that the intervall is closed. Wo move to the next one.
                mergedIntervalls.Add(lastIntervall);
                lastIntervall = currenIntervall;
            }
        }
        // In the end, we add the last intervall to the merge-list, because it has no following intervall.
        mergedIntervalls.Add(lastIntervall);
    
        // output our merge-result
        int set = 0;
        foreach (MyIntervall currenIntervall in mergedIntervalls)
        {
            Console.WriteLine("#{0}: Start {1}, End {2}", ++set, currenIntervall.Start, currenIntervall.End);
        }
    
        // this is the result of the merge
        List<MyIntervall> resultList = new List<MyIntervall>()
        {
            new MyIntervall(new DateTime(2018, 1, 19, 10, 0, 0), new DateTime(2018, 1, 19, 17, 0, 0)),
            new MyIntervall(new DateTime(2018, 1, 19, 19, 0, 0), new DateTime(2018, 1, 19, 20, 0, 0)),
            new MyIntervall(new DateTime(2018, 1, 19, 22, 0, 0), new DateTime(2018, 1, 19, 23, 0, 0))
        };
    }
