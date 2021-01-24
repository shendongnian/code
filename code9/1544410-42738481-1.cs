    public interface IRepo<Item> {
        public List<Item> Read(bool arg);
    }
    public abstract class ServiceBase<TEntity,TModel, TRepo> : IService<TModel> where TRepo : IRepo<TEntity>
    {
        protected internal abstract List<TEntity> EList { get; private set; }
        protected internal TRepo repo { get; private set; };
        public ServiceBase(TRepo instance)
        {
            this.repo = instance;
            this.EList = this.repo.Read(false);
        }
    }
    public class ItemModifierService : ServiceBase<ItemModifierEntity, ItemModifierModel, ItemModifierRepository> {
        public ItemModifierService() : base(new ItemModifierRepository()) {
        }
    }
