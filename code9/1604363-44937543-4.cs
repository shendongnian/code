	public static IEnumerable<Dog> MergeDupDogs(IEnumerable<Dog> dogsA, IEnumerable<Dog> dogsB) {
		var dogsAReduced = dogsA.Aggregate(new Dictionary<int, Dog>(), (acc, da) => {
			if (!acc.ContainsKey(da.ID))
				acc.Add(da.ID, da);
			else
				acc[da.ID] = new Dog { ID = da.ID, Owner = $"{acc[da.ID].Owner}/{da.Owner}", Breed = da.Breed, Colour = da.Colour };
			return acc;
		});
		return dogsB.Aggregate(dogsAReduced, (acc, db) => {
			if (!acc.ContainsKey(db.ID))
				acc.Add(db.ID, db);
			else
				acc[db.ID] = new Dog { ID = db.ID, Owner = $"{acc[db.ID].Owner}/{db.Owner}", Breed = db.Breed, Colour = db.Colour };
			return acc;
		}).Select(e => e.Value);
	}
