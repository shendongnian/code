    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new schedulerEntities())
            {
                var schedules = db.Schedules.ToArray();
                foreach (var schedule in schedules)
                {
                    Console.WriteLine($"{schedule.Cron} - {schedule.FriendlyDescription}");
                }
            }
            Console.ReadLine();
        }
    }
    public partial class Schedule: MyStupidClass, IScheduler
    {
        public string FirstName { get; set; }
    }
    public class MyStupidClass
    {
        public EntityKey EntityKey { get; set; }
        public EntityState State { get; set; }
    }
    interface IScheduler
    {
        long Id { get; set; }
        string Name { get; set; }
        string Cron { get; set; }
    }
