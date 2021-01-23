    public SubjectRepository()
    {
         db = new irfwebpage20161013070934_dbEntities2();
    }
    public SubjectRepository(irfwebpage20161013070934_dbEntities2 dbContext)
    {
         db = dbContext;
    }
