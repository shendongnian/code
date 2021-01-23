    interface IGenericRepository<TObject> where TObject : class {
        TObject Update(TObject data, int id);
    }
    public class GenericRepository<TObject> : IGenericRepository<TObject> where TObject : class {
        protected readonly MyDataContext Context;
        public GenericRepository(MyDataContext context) {
            Context = context;
        }
        public virtual TObject Update(TObject data, int id) {
            if (data == null)
                return null;
            TObject obj = Context.Set<TObject>().Find(id);
            if (obj != null) {
                Context.Entry(obj).CurrentValues.SetValues(data);
                Context.SaveChanges();
            }
            return obj;
        }
    }
