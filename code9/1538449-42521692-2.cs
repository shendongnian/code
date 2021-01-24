	public class DistanceConversionLoggingDecorator
		: Injectivity.DecoratorBase<IDistanceConversion>, IDistanceConversion
	{
		public double MilesToKilometres(double miles)
		{
			Console.WriteLine("CONVERTING " + miles);
			return this.Inner.MilesToKilometres(miles);
		}
	}
