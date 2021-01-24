	var basep = (from p in personList select p.Id).OrderBy(id => id);
	int basepCount = personList.Count();
	int blocksize = 1000;
	int numblocks = (basepCount / blocksize) + (basepCount % blocksize == 0 ? 0 : 1);
	for (var block = 0; block < numblocks; ++block) {
		var firstPersonId = basep.Skip(block * blocksize).First();
		var lastPersonId = basep.Skip(Math.Min(basepCount-1, block*blocksize+blocksize-1)).First();
		var query = from p in personList.Where(ps => firstPersonId.CompareTo(ps.Id) <= 0 && ps.Id.CompareTo(lastPersonId) <= 0)
					join a in accountList on p.Id equals a.PersonId
					where a.Amount < 100
					select a;
		var groups = query.GroupBy(a => a.PersonId);
		// work on groups
	}
