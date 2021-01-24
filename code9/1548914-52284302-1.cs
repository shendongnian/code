    public Patient GetById(int id, Func<IQueryable<Patient>, IIncludableQueryable<Patient, object>> includes = null)
    		{
    			IQueryable<Patient> queryable = context.Patients;
    
    			if (includes != null)
                {
                    queryable = includes(queryable);
                }
    
    			return  queryable.FirstOrDefault(x => x.PatientId == id);
    		}
    
    var patient = GetById(1, includes: source => source.Include(x => x.Relationship1).ThenInclude(x => x.Relationship2));
