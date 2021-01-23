	namespace Tests.Builders
	{
		internal static class Logging
		{
			public static ILogger DefaultLogger()
			{
				return NullLogger();
			}
			public static ILogger NullLogger()
			{
				return Substitute.For<ILogger>();
			}
			public static ILogger XUnitLogger(ITestOutputHelper testOutputHelper)
			{
				// Step 1. Create configuration object 
				var config = new LoggingConfiguration();
				// Step 2. Create targets and add them to the configuration 
				var consoleTarget = new XUnitTarget(testOutputHelper);
				config.AddTarget("xunit", consoleTarget);
				// Step 3. Set target properties 
				consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
				// Step 4. Define rules
				var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);
				config.LoggingRules.Add(rule1);
				// Step 5. Activate the configuration
				LogManager.Configuration = config;
				return LogManager.GetLogger("");
			}
		}
		[Target("XUnit")]
		public sealed class XUnitTarget : TargetWithLayout
		{
			private readonly ITestOutputHelper _output;
			public XUnitTarget(ITestOutputHelper testOutputHelper)
			{
				_output = testOutputHelper;
			}
			protected override void Write(LogEventInfo logEvent)
			{
				string logMessage = this.Layout.Render(logEvent);
				_output.WriteLine(logMessage);
			}
		}
	}
	public class SomeTests
	{
		private readonly ITestOutputHelper _output;
		public SomeTests(ITestOutputHelper output)
		{
			_output = output;
		}
		[Fact]
		public void Lets_see_some_output()
		{
			var foo = new Foo(Logging.XUnitLogger(_output));
			var result = foo.ExecuteSomething();
			Assert.Equal(true, result);
		}
	}
