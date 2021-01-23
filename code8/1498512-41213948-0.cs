    public class Program
    {
        static void Main(string[] args)
        {
            //Hp --> Note: While creating factory instance we are passing interface type.
            var factory = ReminderFactory<IIdentifiableEntity>.GetReminder("Invoicing");
            var x = factory.GetRemindersToBeSent(new InvoiceRepository());
            //Hp --> Note: While reading data we need to cast to corrsponding concreate class type.
            x.Cast<InvoiceSummary>().ToList().ForEach(item =>
            Console.WriteLine($"{item.EntityName}:{item.TotalAmount}"));
            Console.ReadKey();
        }
    }
    public interface IRepository<out T>
    {
        // Hp --> Note: You can't use setter since T it is out parameter (covariant)
        IEnumerable<T> List { get; }
    }
    public interface IReminder<out T> where T : class, IIdentifiableEntity
    {
        //Hp --> Note: You can't use IRepository<T> here since T is out parameter (covariant)
        //Instead of T use interface IIdentifiableEntity
        IEnumerable<T> GetRemindersToBeSent(IRepository<IIdentifiableEntity> repository);
    }
    public class TimesheetReminder : IReminder<InvoiceSummary>
    {
        public IEnumerable<InvoiceSummary> GetRemindersToBeSent(
            //Hp --> Note: We need to cast IIdentifiableEntity to corrsponding concreate class type.
            IRepository<IIdentifiableEntity> repository) =>
            repository.List.Where(I => IsEqual("Invoice", I.EntityName)).Cast<InvoiceSummary>();
        private bool IsEqual(string source, string target) =>
           string.Equals(source, target, StringComparison.CurrentCultureIgnoreCase);
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
