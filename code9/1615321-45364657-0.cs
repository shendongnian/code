    public static List<blabla> AddOrUpdate(this List<blabla> i, Person p)
	{
		i = i ?? new List<blabla>();
		i.RemoveAll(t => t.Id == p.Id && t.Role == RoleEnum.Admin);
		i.Add(p);
		return i;
	}
    TeamWork = TeamWork.AddOrUpdate(aPersonA);
    TeamWork = TeamWork.AddOrUpdate(aPersonB);
    DoSomething(Teamwork);
