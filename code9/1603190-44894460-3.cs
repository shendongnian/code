	public static IEnumerable<IEnumerable<T>> ParametersWithEmpty<T>(this IEnumerable<IEnumerable<T>> ParmLists) {
		if (ParmLists.Count() == 0)
			yield break; // empty
		else {
			var rest = ParametersWithEmpty(ParmLists.Skip(1));
			foreach (var p in ParmLists.First()) {
				yield return p.AsSingleton(); // p.Concat(empty)
				foreach (var r in rest)
					yield return r.Prepend(p); // p.Concat(r)
			}
			foreach (var r in rest)
				yield return r; // empty.Concat(r)
		}
	}
