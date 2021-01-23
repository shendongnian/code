    public class Penalties
    {
        // What about this choice of "int" (vs. decimal)?
        public virtual int ComputeOverdueDaysPenalty(int penaltyPerOverdueDay, DateTime dueDate)
        {
            // Work only with year, month, day, to drop time info and ignore time zone
            dueDate = new DateTime(dueDate.Year, dueDate.Month, dueDate.Day);
            var now = DateTime.Now;
            now = new DateTime(now.Year, now.Month, now.Day);
            return now > dueDate ? (int)now.Subtract(dueDate).TotalDays * penaltyPerOverdueDay : 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var penalties = new Penalties();
            var now = DateTime.Now;
            // due = today
            // should print 0
            Console.WriteLine(penalties.ComputeOverdueDaysPenalty(1234, new DateTime(now.Year, now.Month, now.Day)));
            // due = today plus 1
            var dueDate = now.AddDays(1);
            // should print 0 again
            Console.WriteLine(penalties.ComputeOverdueDaysPenalty(1234, dueDate));
            // due = today minus 1
            dueDate = dueDate.Subtract(new TimeSpan(48, 0, 0));
            // should print 1234
            Console.WriteLine(penalties.ComputeOverdueDaysPenalty(1234, dueDate));
            // due = today minus 2
            dueDate = dueDate.Subtract(new TimeSpan(24, 0, 0));
            // should print 2468
            Console.WriteLine(penalties.ComputeOverdueDaysPenalty(1234, dueDate));
            dueDate = DateTime.Parse("2016-10-02");
            // should print 12340, as of 10/12/2016
            Console.WriteLine(penalties.ComputeOverdueDaysPenalty(1234, dueDate));
            Console.ReadKey();
        }
    }
