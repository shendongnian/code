    private readonly  IMyRepository _iMyRepository;    
    DbContext _dbContext=new DbContext("someParameter","connectionstring");
    
    public MyManager(IMyRepository iMyRepository, DbContext dbContext)                    
    {      
         _iMyRepository=iMyRepository;
         _dbContext=dbContext;
    }
