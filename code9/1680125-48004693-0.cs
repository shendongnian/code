	private static IEnumerable<Assembly> GetReferencedAssemblies(Assembly a, HashSet<string> visitedAssemblies = null)
	{
		visitedAssemblies = visitedAssemblies ?? new HashSet<string>();
		if (!visitedAssemblies.Add(a.GetName().EscapedCodeBase))
		{
			yield break;
		}
		foreach (var assemblyRef in a.GetReferencedAssemblies())
		{
			if (visitedAssemblies.Contains(assemblyRef.EscapedCodeBase)) { continue; }
			var loadedAssembly = Assembly.Load(assemblyRef);
			yield return loadedAssembly;
			foreach (var referenced in GetReferencedAssemblies(loadedAssembly, visitedAssemblies))
			{
				yield return referenced;
			}
		}
	}
