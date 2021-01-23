	public static readonly ISessionFactory SessionFactory = DbContext.SessionFactory();
    	    
    public Candidate GetUser(int id)
    {
		Candidate candidate = null;
		using (var session = SessionFactory.OpenSession())
		{
			candidate = Session.Query<Candidate>().FirstOrDefault(x => x.Id == id);
		}
		return candidate;        
    }
    public void AddCandidate(Candidate candidate)
    {
		using (var session = SessionFactory.OpenSession())
		{
			using (var transaction = session.BeginTransaction())
			{
				try
				{
					Session.Save(candidate);
					transaction.Commit();
				}
				catch 
				{
					transaction.RollBack();
					throw;
				}
			}
		}
    }
