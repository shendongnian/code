    public abstract class FormBase<T> : Form
        where T : BaseCore
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        /// <summary>
        /// Accessor for the DbSet
        /// </summary>
        protected DbSet<T> DbSet
        {
            get { return _db.Set<T>(); }
        }
        /// <summary>
        /// Inform the DbContext of the changes made on an entity
        /// </summary>
        /// <param name="entity"></param>
        protected void UpdateEntry(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// Save changes on the DbContext
        /// </summary>
        protected void SaveData()
        {
            _db.SaveChanges();
        }
    }
