	void Main()
	{
		// Somewhere in my configuration
		var injectivity = Injectivity.Context.CreateRoot();
		injectivity.SetFactory<IDistanceConversion, DistanceConversion>();
		// Here's the previous example using dependency injection.
		var dc = injectivity.Resolve<IDistanceConversion>();
		var miles = 4.5;
		Console.WriteLine("{0} miles is {1} kilometres", miles, dc.MilesToKilometres(miles));
	}
	
	public interface IDistanceConversion
	{
		double MilesToKilometres(double miles);
	}
	
	public class DistanceConversion : IDistanceConversion
	{
		public double MilesToKilometres(double miles)
		{
			return miles * 8.0 / 5.0;
		}
	}
