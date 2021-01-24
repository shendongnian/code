	public class Program
	{
		public static void Main()
		{
			var input = " 0759651386    X08  606 0209784104 BURTON                                             3334.24";
			
			var line = new DetailRecord(input);
			if (line.IsValid)
			{
				Console.WriteLine("Contract number: '{0}'", line.ContractNo);
				Console.WriteLine("Bank number: '{0}'", line.BankNum);
				Console.WriteLine("Short name: '{0}'", line.ShortName);
			}
		}
	}
