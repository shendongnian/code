    public class Program
    {
        static void Main(string[] args)
        {
            //Hp --> Logic: Create factory instance by passing concrete class type.
            var factory = ReminderFactory.Create<InvoiceSummary>();
            var x = factory.GetRemindersToBeSent(new InvoiceRepository());
            x.ToList().ForEach(item =>
            Console.WriteLine($"{item.EntityName}:{item.TotalAmount}"));
            Console.ReadKey();
        }
    }
    public interface IIdentifiableEntity
    {
        string EntityName { get; set; }
    }
    public static class ReminderFactory
    {
        public static IReminder<T> Create<T>() where T : class, IIdentifiableEntity
        {
            IReminder<T> reminder = null;
            if (typeof(InvoiceSummary) == typeof(T))
            {
                reminder = new TimesheetReminder() as IReminder<T>;
            }
            return reminder;
        }
    }
    public interface IReminder<T> where T : class, IIdentifiableEntity
    {
        IEnumerable<T> GetRemindersToBeSent(IRepository<T> repository);
    }
    public interface IRepository<T>
    {
        IEnumerable<T> List { get; }
    }
    public class InvoiceRepository : IRepository<InvoiceSummary>
    {
        public IEnumerable<InvoiceSummary> List => new List<InvoiceSummary> {
            new InvoiceSummary { EntityName = "Invoice", TotalAmount = 100.00M } };
    }
    public class InvoiceSummary : IIdentifiableEntity
    {
        public string EntityName { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class TimesheetReminder : IReminder<InvoiceSummary>
    {
        public IEnumerable<InvoiceSummary> GetRemindersToBeSent(
            IRepository<InvoiceSummary> repository) =>
            repository.List.Where(I => IsEqual("Invoice", I.EntityName));
        private bool IsEqual(string source, string target) =>
           string.Equals(source, target, StringComparison.CurrentCultureIgnoreCase);
    }
