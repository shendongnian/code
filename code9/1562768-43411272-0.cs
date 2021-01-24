    public static void Main(string[] args)
		{
			string eName, totalSales;
			double gPay, tots, fed, sec, ret, tdec,thome;
			instructions();
			eName = getInfo("Name");
			totalSales = getInfo("TotalSales");
			tots = double.Parse(totalSales);
			gPay = totalGpay(tots);
}
    public static string getInfo(string info)
		{
			string inputValue;
			Console.WriteLine("Information of the employee: {0}", info);
			inputValue = Console.ReadLine();
			return inputValue;
		}
