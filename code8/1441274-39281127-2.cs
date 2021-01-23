    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace SandboxConsole
    {
	class Program
	{
		static void Main(string[] args)
		{
			var t = new Transactions();
			List<Transactions> transactions = t.GetTransactions();
			// Now let's add a Weeks end date so we can determine the average per week
			foreach(var transaction in transactions)
			{
				var transactionDayOfWeek = transaction.TransactionDate;
				int daysUntilEndOfWeek_Sat = ((int)DayOfWeek.Saturday - (int)transactionDayOfWeek.DayOfWeek + 7) % 7;
				transaction.Newly_Added_Property_To_Group_By_Week_To_Get_Averages = transactionDayOfWeek.AddDays(daysUntilEndOfWeek_Sat).ToShortDateString();
				//Console.WriteLine("{0} {")
			}
			
			foreach(var weekEnd in transactions.GroupBy(tt => tt.Newly_Added_Property_To_Group_By_Week_To_Get_Averages))
			{
				decimal weekTotal = 0;
				foreach(var trans in weekEnd)
				{
					weekTotal += trans.Amount;
				}
				var weekAverage = weekTotal / 7;
				Console.WriteLine("Week End: {0} - Avg {1}", weekEnd.Key.ToString(), weekAverage.ToString("C"));
			}
			Console.ReadKey();
		}
	}
	class Transactions
	{
		public int Id { get; set; }
		public string SomeOtherProp { get; set; }
		public DateTime TransactionDate { get; set; }
		public decimal Amount { get; set; }
		public string Newly_Added_Property_To_Group_By_Week_To_Get_Averages { get; set; }
		public List<Transactions> GetTransactions()
		{
			var results = new List<Transactions>();
			
			for(var i = 0; i<100; i++)
			{
				results.Add(new Transactions
				{
					Id = i,
					SomeOtherProp = "Customer " + i.ToString(),
					TransactionDate = GetRandomDate(i),
					Amount = GetRandomAmount()
				});
			}
			
			return results;
		}
		public DateTime GetRandomDate(int i)
		{
			Random gen = new Random();
			DateTime startTime = new DateTime(2016, 1, 1);
			int range = (DateTime.Today - startTime).Days + i;
			return startTime.AddDays(gen.Next(range));
		}
		public int GetRandomAmount()
		{
			Random rnd = new Random();
			int amount = rnd.Next(1000, 10000);
			return amount;
		}
	}
