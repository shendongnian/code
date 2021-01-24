	public static IObservable<IEnumerable<T>> CumulativeAdded<T>(this IObservable<IEnumerable<T>> src) {
		var memadd = new HashSet<T>();
		return src.Select(x => x.Where(n => memadd.Add(n)));
	}
	public static IObservable<IEnumerable<T>> CumulativeRemoved<T>(this IObservable<IEnumerable<T>> src) {
		var memdiff = new HashSet<T>();
		return src.Select(x => { foreach (var n in x) memdiff.Add(n); return memdiff.AsEnumerable().Except(x); });
	}
}
