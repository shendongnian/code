    public static class X
    {
    	public static (IObservable<T> trues, IObservable<T> falsies) Partition<T>(this IObservable<T> source, Func<T, bool> partitioner)
    	{
    		var x = source.GroupBy(partitioner);
    		var trues = x.Where(g => g.Key == true).Merge();
    		var falsies = x.Where(g => g.Key == false).Merge();
    		return (trues, falsies);
    	}
    }
