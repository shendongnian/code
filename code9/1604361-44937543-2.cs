	public static IEnumerable<T> Prepend<T>(this IEnumerable<T> rest, params T[] first) => first.Concat(rest);
	public static IEnumerable<Dog> MergeDupDogs(IEnumerable<Dog> dogsA, IEnumerable<Dog> dogsB) {
		var dogsAReduced = dogsA.Aggregate(Enumerable.Empty<Dog>(), (acc, da) => {
			if (!acc.Any(accd => accd.ID == da.ID))
				return acc.Prepend(da);
			else
				return acc.Select(accd => (accd.ID == da.ID) ? new Dog { ID = accd.ID, Owner = $"{accd.Owner}/{da.Owner}", Breed = accd.Breed, Colour = accd.Colour } : accd);
		});
		return dogsB.Aggregate(dogsAReduced, (acc, da) => {
			if (!acc.Any(accd => accd.ID == da.ID))
				return acc.Prepend(da);
			else
				return acc.Select(accd => (accd.ID == da.ID) ? new Dog { ID = accd.ID, Owner = $"{accd.Owner}/{da.Owner}", Breed = accd.Breed, Colour = accd.Colour } : accd);
		});
	}
