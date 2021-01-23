    // Never use this, unless you are using only one entity (e.g user)
    // and not using two or more related (e.g users and roles)
    // public BaseRepository()
    // {
    //     db = new BookATableContext();
    //     dbSet = db.Set<T>();          
    // }
    public BaseRepository(UnitOfWork unitOfWork)
    {         
        // Don't create a new DbContext instance, use a unique shared instance
        // from UnitOfWork          
        // db = new BookATableContext();
        dbSet = db.Set<T>();
        this.unitOfWork = unitOfWork;   
        this.db = unitOfWork.db;
    }
