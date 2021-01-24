    public static class ReactivePropertyExtensions
    {
    	public static ReactiveProperty<T> ToReactiveProperty<T>(this IObservable<T> source)
    	{
    		return new ReactiveProperty<T>(source);
    	}
    
    	public static ReactiveProperty<T> ToReactiveProperty<T>(this IObservable<T> source, T defaultValue)
    	{
    		return new ReactiveProperty<T>(source, defaultValue);
    	}
    }
    
    public class ReactiveProperty<T> : IDisposable
    {
    	private IObservable<T> Source { get; }
    	private IDisposable Subscription { get; }
    	public T Value { get; private set; }
    	
    	public ReactiveProperty(IObservable<T> source)
    		: this(source, default(T)) { }
    		
        public ReactiveProperty(IObservable<T> source, T defaultValue)
    	{
    		Value = defaultValue;
    		Source = source;
    		Subscription = source.Subscribe(t => Value = t);
    	}
    	
    	public void Dispose()
    	{
    		Subscription.Dispose();
    	}
    }
