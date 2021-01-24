	internal sealed class DapperExtensionsProxy
	{
		internal DapperExtensionsProxy(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
		IUnitOfWork unitOfWork = null;
		internal int Count<T>(object predicate) where T : BasePoco
		{
			var result = unitOfWork.Connection.Count<T>(predicate, unitOfWork.Transaction);
			return result;
		}
		internal T Get<T>(object id) where T : BasePoco
		{
			var result = unitOfWork.Connection.Get<T>(id, unitOfWork.Transaction);
			return result;
		}
		internal IEnumerable<T> GetList<T>(object predicate, IList<ISort> sort = null, bool buffered = false) where T : BasePoco
		{
			var result = unitOfWork.Connection.GetList<T>(predicate, sort, unitOfWork.Transaction, null, buffered);
			return result;
		}
		internal IEnumerable<T> GetPage<T>(object predicate, int page, int resultsPerPage, IList<ISort> sort = null, bool buffered = false) where T : BasePoco
		{
			var result = unitOfWork.Connection.GetPage<T>(predicate, sort, page, resultsPerPage, unitOfWork.Transaction, null, buffered);
			return result;
		}
		internal dynamic Insert<T>(T poco) where T : BasePoco
		{
			var result = unitOfWork.Connection.Insert<T>(poco, unitOfWork.Transaction);
			return result;
		}
		internal void Insert<T>(IEnumerable<T> listPoco) where T : BasePoco
		{
			unitOfWork.Connection.Insert<T>(listPoco, unitOfWork.Transaction);
		}
		internal bool Update<T>(T poco) where T : BasePoco
		{
			var result = unitOfWork.Connection.Update<T>(poco, unitOfWork.Transaction);
			return result;
		}
		internal bool Delete<T>(T poco) where T : BasePoco
		{
			var result = unitOfWork.Connection.Delete<T>(poco, unitOfWork.Transaction);
			return result;
		}
		internal bool Delete<T>(object predicate) where T : BasePoco
		{
			var result = unitOfWork.Connection.Delete<T>(predicate, unitOfWork.Transaction);
			return result;
		}
	}
