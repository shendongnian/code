	class DictionaryOfControlsLists
	{
	    private readonly Dictionary<Type, IListOfControls<Control>> _dictionaryOfLists = new Dictionary<Type, IListOfControls<Control>>();
	
		public void Add<T>(T control) where T : Control
		{
			if (!_dictionaryOfLists.ContainsKey(typeof(T)))
			{
				_dictionaryOfLists[typeof(T)] = new ListOfControls<Control>();
			}
			_dictionaryOfLists[typeof(T)].AddControl(control);
		}
		
		public T Get<T>(int number) where T : Control
		{
			if (!_dictionaryOfLists.ContainsKey(typeof(T)))
			{
				_dictionaryOfLists[typeof(T)] = new ListOfControls<Control>();
			}
			return _dictionaryOfLists[typeof(T)][number] as T;
		}
	}
