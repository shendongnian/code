	public abstract class BaseRepository<T> where T : BasePoco
	{
		internal BaseRepository(IUnitOfWork unitOfWork)
		{
			dapperExtensionsProxy = new DapperExtensionsProxy(unitOfWork);
		}
		DapperExtensionsProxy dapperExtensionsProxy = null;
		protected bool Exists()
		{
			return (GetCount() == 0) ? false : true;
		}
		protected int GetCount()
		{
			var result = dapperExtensionsProxy.Count<T>(null);
			return result;
		}
		protected T GetById(Guid id)
		{
			var result = dapperExtensionsProxy.Get<T>(id);
			return result;
		}
		protected T GetById(string id)
		{
			var result = dapperExtensionsProxy.Get<T>(id);
			return result;
		}
		protected List<T> GetList()
		{
			var result = dapperExtensionsProxy.GetList<T>(null);
			return result.ToList();
		}
		protected void Insert(T poco)
		{
			var result = dapperExtensionsProxy.Insert(poco);
		}
		protected void Update(T poco)
		{
			var result = dapperExtensionsProxy.Update(poco);
		}
		protected void Delete(T poco)
		{
			var result = dapperExtensionsProxy.Delete(poco);
		}
		protected void DeleteById(Guid id)
		{
			T poco = (T)Activator.CreateInstance(typeof(T));
			poco.SetDbId(id);
			var result = dapperExtensionsProxy.Delete(poco);
		}
		protected void DeleteById(string id)
		{
			T poco = (T)Activator.CreateInstance(typeof(T));
			poco.SetDbId(id);
			var result = dapperExtensionsProxy.Delete(poco);
		}
		protected void DeleteAll()
		{
			var predicateGroup = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
			var result = dapperExtensionsProxy.Delete<T>(predicateGroup);//Send empty predicateGroup to delete all records.
		}
