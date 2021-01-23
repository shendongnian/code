    public class Base`enter code here`Service<T> where T: BaseEntity, new()
    {
        private BaseRepository<T> Repository;
        protected UnitOfWork unitOfWork;
    
        // Must not use this constructor, we always need the unitofWork to share DbContext
        // public BaseService()
        // {
        //     this.Repository = new BaseRepository<T>();
        // }
    
        public BaseService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.Repository = new BaseRepository<T>(this.unitOfWork);
    
        }
    }
