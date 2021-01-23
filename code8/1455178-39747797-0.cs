    public class Service<T> : Interface.IService<T> where T : class
    {
        Interface.IService<T> implementation;
        public virtual event System.EventHandler<EntitySavingEventArgs<T>> BeforeSavingRecord;
        public virtual event System.EventHandler<EntitySavingEventArgs<T>> SavingRecord;
        public virtual event System.EventHandler<EntitySavingEventArgs<T>> RecordSaved;
        public void PopulateEvents(Interface.IService<T> _implementation)
        {
            implementation = _implementation;
            implementation.BeforeSavingRecord += new System.EventHandler<EntitySavingEventArgs<T>>(this.OnBeforeSavingRecord);
            implementation.SavingRecord += new System.EventHandler<EntitySavingEventArgs<T>>(this.OnSavingRecord);
            implementation.RecordSaved += new System.EventHandler<EntitySavingEventArgs<T>>(this.OnRecordSaved);
        }
        public virtual void OnBeforeSavingRecord(object sender, EntitySavingEventArgs<T> e)
        {
        }
        public virtual void OnSavingRecord(object sender, EntitySavingEventArgs<T> e)
        {
        }
        public virtual void OnRecordSaved(object sender, EntitySavingEventArgs<T> e)
        {
        }
        private readonly DbContext _dbContext;
        public Service(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual void Create(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            BeforeSavingRecord?.Invoke(this, new EntitySavingEventArgs<T>() { SavedEntity = item });
            _dbContext.Set(typeof(T)).Add(item);
            SavingRecord?.Invoke(this, new EntitySavingEventArgs<T>() { SavedEntity = item });
            _dbContext.SaveChanges();
            RecordSaved?.Invoke(this, new EntitySavingEventArgs<T>() { SavedEntity = item });
        }
    }
