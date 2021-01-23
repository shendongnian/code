	public class ModuleProvider
	{
		private Dictionary<ViewType, Func<List<ITreeNode>>> _factory;
		
		public ModuleProvider(Dictionary<ViewType, Func<List<ITreeNode>>> factory)
		{
			_factory = factory;
		}
		
		public List<ITreeNode> GetModules(ViewType viewType)
		{
			return _factory[viewType]();
		}
	}
