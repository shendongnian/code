	public class ManagerBase<M, T1>
		where M : ManagerBase<M, T1>
		where T1 : ChildBase<M, T1>
	{
		public ManagerBase()
		{
			ChildObjects = new List<T1>();
		}
	
		public List<T1> ChildObjects { get; set; }
	}
	
	public class ChildBase<T1, C>
		where T1 : ManagerBase<T1, C>
		where C : ChildBase<T1, C>
	{
		public ChildBase(T1 parentMgr)
		{
			ParentMgr = parentMgr;
			ParentMgr.ChildObjects.Add((C)(object)this);
		}
	
		public T1 ParentMgr { get; set; }
	}
