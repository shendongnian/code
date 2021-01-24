    public static class Program
    {
    	public static void Main(params string[] args)
    	{
    		var stepCount = 5000000UL;
    
    		var dummy = new Dummy();
    
    		const string propertyName = "Soother";
    
    		const bool propertyValue = true;
    
    		var propertyInfo = typeof(Dummy).GetProperty(propertyName);
    
    		var lambdaExpression = FastPropertyFactory.GeneratePropertySetter<Dummy, bool>(propertyName);
    
    		var nativeBenchmark = Benchmark.Run("Native", stepCount, () => dummy.Soother = propertyValue);
    		var lambdaExpressionBenchmark = Benchmark.Run("Lambda Expression", stepCount, () => lambdaExpression(dummy, propertyValue));
    		var dictionaryLambdaExpressionBenchmark = Benchmark.Run("Dictionary Access + Lambda Expression", stepCount, () => dummy.Set(propertyName, propertyValue));
    		var propertyInfoBenchmark = Benchmark.Run("Property Info", stepCount, () => propertyInfo.SetValue(dummy, propertyValue, null));
    
    		var benchmarkReports = new[]
    		{
    			nativeBenchmark,
    			lambdaExpressionBenchmark,
    			dictionaryLambdaExpressionBenchmark,
    			propertyInfoBenchmark
    		}.OrderBy(item => item.ElapsedMilliseconds);
    
    		benchmarkReports.Join(Environment.NewLine).WriteLineToConsole();
    
    		var fastest = benchmarkReports.First().ElapsedMilliseconds;
    
    		benchmarkReports.Select(report => (report.ElapsedMilliseconds / fastest).ToString("0.000")).Join(" < ").WriteLineToConsole();
    
    		var dictionaryAccess = (dictionaryLambdaExpressionBenchmark.ElapsedMilliseconds / lambdaExpressionBenchmark.ElapsedMilliseconds * 100);
    		("Dictionary Access: " + dictionaryAccess + " %").WriteLineToConsole();
    
    		Console.ReadKey();
    	}
    }
    
    public class Dummy
    {
    	public Dummy(bool soother = true)
    	{
    		Soother = soother;
    	}
    
    	public bool? Soother { get; set; }
    }
    
    public class BenchMarkReport
    {
    	#region Fields & Properties
    
    	public string Name { get; }
    
    	public TimeSpan ElapsedTime { get; }
    
    	public double ElapsedMilliseconds => ElapsedTime.TotalMilliseconds;
    
    	public ulong StepCount { get; }
    
    	public double StepElapsedMilliseconds => ElapsedMilliseconds / StepCount;
    
    	#endregion
    
    	#region Constructors
    
    	internal BenchMarkReport(string name, TimeSpan elapsedTime, ulong stepCount)
    	{
    		Name = name;
    		ElapsedTime = elapsedTime;
    		StepCount = stepCount;
    	}
    
    	#endregion
    
    	#region Methods
    
    	public override string ToString()
    	{
    		return $"{Name}: Elapsed = {ElapsedTime} ({ElapsedMilliseconds} ms); Step = {StepElapsedMilliseconds:0.###E+000} ms";
    	}
    
    	#endregion
    }
    
    public class Benchmark
    {
    	#region Fields & Properties
    
    	private readonly Action _stepAction;
    
    	public string Name { get; }
    
    	public ulong StepCount { get; }
    
    	public Benchmark(string name, ulong stepCount, Action stepAction)
    	{
    		Name = name;
    		StepCount = stepCount;
    		_stepAction = stepAction;
    	}
    
    	#endregion
    
    	#region Constructors
    
    	#endregion
    
    	#region Methods
    
    	public static BenchMarkReport Run(string name, ulong stepCount, Action stepAction)
    	{
    		var benchmark = new Benchmark(name, stepCount, stepAction);
    
    		var benchmarkReport = benchmark.Run();
    
    		return benchmarkReport;
    	}
    
    	public BenchMarkReport Run()
    	{
    		return Run(StepCount);
    	}
    
    	public BenchMarkReport Run(ulong stepCountOverride)
    	{
    		var stopwatch = Stopwatch.StartNew();
    
    		for (ulong i = 0; i < StepCount; i++)
    		{
    			_stepAction();
    		}
    
    		stopwatch.Stop();
    
    		var benchmarkReport = new BenchMarkReport(Name, stopwatch.Elapsed, stepCountOverride);
    
    		return benchmarkReport;
    	}
    
    	#endregion
    }
    
    public static class ObjectExtensions
    {
    	public static void WriteToConsole<TInstance>(this TInstance instance)
    	{
    		Console.Write(instance);
    	}
    
    	public static void WriteLineToConsole<TInstance>(this TInstance instance)
    	{
    		Console.WriteLine(instance);
    	}
    
    	// Goodies: add name inference from property lambda expression
    	// e.g. "instance => instance.PropertyName" redirected using "PropertyName"
    
    	public static TProperty Get<TInstance, TProperty>(this TInstance instance, string propertyName)
    	{
    		return FastPropertyRepository<TInstance, TProperty>.GetGetter(propertyName)(instance);
    	}
    
    	public static void Set<TInstance, TProperty>(this TInstance instance, string propertyName, TProperty propertyValue)
    	{
    		FastPropertyRepository<TInstance, TProperty>.GetSetter(propertyName)(instance, propertyValue);
    	}
    }
    
    public static class EnumerableExtensions
    {
    	public static string Join<TSource>(this IEnumerable<TSource> source, string separator = ", ")
    	{
    		return string.Join(separator, source);
    	}
    }
    
    internal static class FastPropertyRepository<TInstance, TProperty>
    {
    	private static readonly IDictionary<string, Action<TInstance, TProperty>> Setters;
    	private static readonly IDictionary<string, Func<TInstance, TProperty>> Getters;
    
    	static FastPropertyRepository()
    	{
    		Getters = new ConcurrentDictionary<string, Func<TInstance, TProperty>>();
    		Setters = new ConcurrentDictionary<string, Action<TInstance, TProperty>>();
    	}
    
    	public static Func<TInstance, TProperty> GetGetter(string propertyName)
    	{
    		if (!Getters.TryGetValue(propertyName, out Func<TInstance, TProperty> getter))
    		{
    			getter = FastPropertyFactory.GeneratePropertyGetter<TInstance, TProperty>(propertyName);
    			Getters[propertyName] = getter;
    		}
    
    		return getter;
    	}
    
    	public static Action<TInstance, TProperty> GetSetter(string propertyName)
    	{
    		if (!Setters.TryGetValue(propertyName, out Action<TInstance, TProperty> setter))
    		{
    			setter = FastPropertyFactory.GeneratePropertySetter<TInstance, TProperty>(propertyName);
    			Setters[propertyName] = setter;
    		}
    
    		return setter;
    	}
    }
    
    internal static class FastPropertyFactory
    {
    	public static Func<TInstance, TProperty> GeneratePropertyGetter<TInstance, TProperty>(string propertyName)
    	{
    		var parameterExpression = Expression.Parameter(typeof(TInstance), "value");
    
    		var propertyValueExpression = Expression.Property(parameterExpression, propertyName);
    
    		var expression = propertyValueExpression.Type == typeof(TProperty) ? propertyValueExpression : (Expression)Expression.Convert(propertyValueExpression, typeof(TProperty));
    
    		var propertyGetter = Expression.Lambda<Func<TInstance, TProperty>>(expression, parameterExpression).Compile();
    
    		return propertyGetter;
    	}
    
    	public static Action<TInstance, TProperty> GeneratePropertySetter<TInstance, TProperty>(string propertyName)
    	{
    		var instanceParameterExpression = Expression.Parameter(typeof(TInstance));
    
    		var parameterExpression = Expression.Parameter(typeof(TProperty), propertyName);
    
    		var propertyValueExpression = Expression.Property(instanceParameterExpression, propertyName);
    
    		var conversionExpression = propertyValueExpression.Type == typeof(TProperty) ? parameterExpression : (Expression)Expression.Convert(parameterExpression, propertyValueExpression.Type);
    
    		var propertySetter = Expression.Lambda<Action<TInstance, TProperty>>(Expression.Assign(propertyValueExpression, conversionExpression), instanceParameterExpression, parameterExpression).Compile();
    
    		return propertySetter;
    	}
    }
