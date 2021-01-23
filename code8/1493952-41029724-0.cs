    public static class Builder
    {
    	public static Level1<T> GetOne<T>(this object obj, string blah) {
    		return new Level1<T>();
    	}
    }
    public class Level1<T1> {
    	public Level2<T1, T2> WithMany<T2>(string blah) { return new Level2<T1, T2>(); }
    	public T Build<T>(Func<T1, T> pred) { return pred(default(T1)); }
    }
    public class Level2<T1, T2>
    {
    	public Level3<T1, T2, T3> WithMany<T3>(string blah) { return new Level3<T1, T2, T3>(); }
    	public T Build<T>(Func<T1, IEnumerable<T2>, T> pred) { return pred(default(T1), default(IEnumerable<T2>)); }
    }
    public class Level3<T1, T2, T3>
    {
    	public T Build<T>(Func<T1, IEnumerable<T2>, IEnumerable<T3>, T> pred) { 
    		return pred(default(T1), default(IEnumerable<T2>), default(IEnumerable<T3>)); 
    	}
    }
