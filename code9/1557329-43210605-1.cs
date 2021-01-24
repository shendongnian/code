	public static bool CompareMatchingProperties<TLeft,TRight>(TLeft lhs, TRight rhs) {
		var allLeft = typeof(TLeft).GetProperties().ToDictionary(p => p.Name);
		var allRight = typeof(TRight).GetProperties().ToDictionary(p => p.Name);
		foreach (var name in allLeft.Keys.Intersect(allRight.Keys)) {
			if (!object.Equals(allLeft[name].GetValue(lhs), allRight[name].GetValue(rhs))) {
				return false;
			}
		}
		return true;
	}
