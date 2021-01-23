    public class Program
    {
        static void Main(string[] args)
        {
            //Hp --> While creating factory instance, must pass concreate class type of T.
            var factory = ReminderFactory<InvoiceSummary>.GetReminder("Invoicing");
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
    public static class ReminderFactory<T> where T : class, IIdentifiableEntity
    {
        public static IReminder<T> GetReminder(string applicationType)
        {
            IReminder<T> reminder;
            switch (applicationType)
            {
                case "Invoicing":
                    reminder = new TimesheetReminder() as IReminder<T>;
                    break;
                default:
                    reminder = null;
                    break;
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
        IEnumerable<T> List { get; set; }
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
