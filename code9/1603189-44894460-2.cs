	public static IEnumerable<IEnumerable<T>> Parameters<T>(this IEnumerable<IEnumerable<T>> ParmLists) {
		if (ParmLists.Count() == 1)
			foreach (var p in ParmLists.First())
				yield return p.AsSingleton();
		else {
			var rest = Parameters(ParmLists.Skip(1));
			foreach (var p in ParmLists.First()) {
				foreach (var r in rest)
					yield return r.Prepend(p);
			}
		}
	}
