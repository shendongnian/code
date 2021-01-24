    /* This is a benchmarking template I use in LINQPad when I want to do a
     * quick performance test. Just give it a couple of actions to test and
     * it will give you a pretty good idea of how long they take compared
     * to one another. It's not perfect: You can expect a 3% error margin
     * under ideal circumstances. But if you're not going to improve
     * performance by more than 3%, you probably don't care anyway.*/
    void Main()
    {
        // Enter setup code here
        var items = new[] { "a, b, c",
        "",
        "a, f, g, h",
        "",
        ""}.AsEnumerable();
        var manyitems = Enumerable.Range(1, 10000).SelectMany(i => items);
    
        var actions = new[]
        {
            new TimedAction("Control", () =>
            {
                // ToList() is the one thing that all of these have to do.
                manyitems.ToList();
            }),
            new TimedAction("Reverse().SkipWhile().Reverse()", () =>
            {
                manyitems.Reverse().SkipWhile(e => !e.Any()).Reverse().ToList();
            }),
            new TimedAction("Take(Reverse().TakeWhile().Count())", () =>
            {
                manyitems.Take(manyitems.Reverse().TakeWhile(e => !e.Any()).Count()).ToList();
            }),
            new TimedAction("SkipLastWhile", () =>
            {
                manyitems.SkipLastWhile(e => !e.Any()).ToList();
            }),
            // Add tests as desired
    	};
    	const int TimesToRun = 100; // Tweak this as necessary
    	TimeActions(TimesToRun, actions);
    }
    
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> SkipLastWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var skipBuffer = new List<T>();
            foreach (var item in source)
            {
                if (predicate(item))
                    skipBuffer.Add(item);
                else
                {
                    foreach (var skipped in skipBuffer)
                        yield return skipped;
                    skipBuffer.Clear();
                    yield return item;
                }
            }
        }
    }
    
    #region timer helper methods
    // Define other methods and classes here
    public void TimeActions(int iterations, params TimedAction[] actions)
    {
    	Stopwatch s = new Stopwatch();
    	int length = actions.Length;
    	var results = new ActionResult[actions.Length];
    	// Perform the actions in their initial order.
    	for (int i = 0; i < length; i++)
    	{
    		var action = actions[i];
    		var result = results[i] = new ActionResult { Message = action.Message };
    		// Do a dry run to get things ramped up/cached
    		result.DryRun1 = s.Time(action.Action, 10);
    		result.FullRun1 = s.Time(action.Action, iterations);
    	}
    	// Perform the actions in reverse order.
    	for (int i = length - 1; i >= 0; i--)
    	{
    		var action = actions[i];
    		var result = results[i];
    		// Do a dry run to get things ramped up/cached
    		result.DryRun2 = s.Time(action.Action, 10);
    		result.FullRun2 = s.Time(action.Action, iterations);
    	}
    	results.Dump();
    }
    
    public class ActionResult
    {
    	public string Message { get; set; }
    	public double DryRun1 { get; set; }
    	public double DryRun2 { get; set; }
    	public double FullRun1 { get; set; }
    	public double FullRun2 { get; set; }
    }
    
    public class TimedAction
    {
    	public TimedAction(string message, Action action)
    	{
    		Message = message;
    		Action = action;
    	}
    	public string Message { get; private set; }
    	public Action Action { get; private set; }
    }
    
    public static class StopwatchExtensions
    {
    	public static double Time(this Stopwatch sw, Action action, int iterations)
    	{
    		sw.Restart();
    		for (int i = 0; i < iterations; i++)
    		{
    			action();
    		}
    		sw.Stop();
    
    		return sw.Elapsed.TotalMilliseconds;
    	}
    }
    #endregion
