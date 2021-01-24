    enum ActiveRepository
    {
        MyEfClass,
        MyOtherEfClass,
    }
    class Service
    {
        private MyEfClass myEfRepository = ...;
        private MyEfClass myOtherRepository = ...;
        public ActiveRepository ActiveRepository {get; set;}
        private IDbSet<MyObject> GetActiveRepository()
        {
           if (this.ActiveRepository == MyEfClass)
               return this.myEfRepository;
           else
               return this.myOtherEfRepository;
        }
