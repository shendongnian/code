	public static IEnumerable<IEnumerable<T>> ParametersWithEmpty2<T>(this IEnumerable<IEnumerable<T>> ParmLists) {
		if (ParmLists.Count() == 0)
			yield return Enumerable.Empty<T>();
		else {
			var rest = ParametersWithEmpty2(ParmLists.Skip(1));
			foreach (var r in rest)
				yield return r; // empty.Concat(r)
			foreach (var p in ParmLists.First()) {
				foreach (var r in rest)
					yield return r.Prepend(p); // p.Concat(r)
			}
		}
	}
