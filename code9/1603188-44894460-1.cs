	public static IEnumerable<IEnumerable<T>> ParametersWithEmpty<T>(this IEnumerable<IEnumerable<T>> ParmLists) {
		if (ParmLists.Count() == 0)
			yield break;
		else {
			var rest = ParametersWithEmpty(ParmLists.Skip(1));
			foreach (var p in ParmLists.First()) {
				yield return p.AsSingleton();
				foreach (var r in rest)
					yield return r.Prepend(p);
			}
			foreach (var r in rest)
				yield return r;
		}
	}
