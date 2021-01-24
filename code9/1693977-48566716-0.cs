	public static IQueryable<Profile> IncludeAll(this IQueryable<Profile> query)
	{
	     return query.Include(x => x.MedicalRecords)
	                 .Include(x => x.DrugHistory)
	                 .Include(x => x.EmploymentStatus);
	}
