		public class Program
		{
			static void Main(string[] args)
			{
				var factory = ReminderFactory<IIdentifiableEntity>.GetReminder("Invoicing");
				var x = factory.GetRemindersToBeSent(new InvoiceRepository());
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
		
		public interface IReminder<out T> where T : class, IIdentifiableEntity
		{
			//Hp --> You can't use IRepository<T> here since T is out parameter (covariant)
			//Instead of T use interface IIdentifiableEntity
			IEnumerable<T> GetRemindersToBeSent(IRepository<IIdentifiableEntity> repository);
		}
		public interface IRepository<out T>
		{
			IEnumerable<T> List { get; } // Hp --> You can't use setter since T it is out parameter (covariant)
		}
		public class InvoiceRepository : IRepository<InvoiceSummary>
		{
			public IEnumerable<InvoiceSummary> List =>
				new List<InvoiceSummary> { new InvoiceSummary { EntityName = "Invoice", TotalAmount = 100.00M } };
		}
		public class InvoiceSummary : IIdentifiableEntity
		{
			public string EntityName { get; set; }
			public decimal TotalAmount { get; set; }
		}
		public class TimesheetReminder : IReminder<InvoiceSummary>
		{
			public IEnumerable<InvoiceSummary> GetRemindersToBeSent(IRepository<IIdentifiableEntity> repository) =>
				repository.List.Where(I => IsEqual("Invoice", I.EntityName)).Cast<InvoiceSummary>();
			private bool IsEqual(string source, string target) =>
			   string.Equals(source, target, StringComparison.CurrentCultureIgnoreCase);
		}
