	[Injectivity.Attributes.Decorator(typeof(IDistanceConversion))]
	public class DistanceConversionLoggingDecorator
		: Injectivity.DecoratorBase<IDistanceConversion>, IDistanceConversion
	{ ... }
	
	[Injectivity.Attributes.Factory(typeof(IDistanceConversion))]
	public class DistanceConversion : IDistanceConversion
	{ ... }
