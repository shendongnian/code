    //Component.cs
    public abstract class Component {
		//...
        protected internal Entity gameObject;
    	private RequiresList _requires;
    	//...
    	protected internal RequiresList Requires
		{
			get => _requires;
			private set => _requires = (RequiresList)value.FindAll(x => x.IsSubclassOf(typeof(Component)));
		}
        //...
        public class RequiresList : List<Type>
		{
			public RequiresList() { }
			public RequiresList(IEnumerable<Type> types) : base(types) { }
			public RequiresList(int capacity) : base(capacity) { }
			public new Type this[int index]
			{
				get => base[index];
				set
				{
					if (isComp(value))
						base[index] = value;
				}
			}
			public new void Add(Type type)
			{
				if (isComp(type))
					base.Add(type);
			}
			private static bool isComp(Type type)
			{
				return type.IsSubclassOf(typeof(Component));
			}
		}
		//...
	}
    //Entity.cs
    public abstract class Entity {
    	//...
    	_components = new List<Component>();
    	//...
    	public T AddComponent<T>() where T : Component, new()
    	{
    	    var temp = new T();
    	    if (_components.Exists((x) => x is T)) return null;
    	    foreach (var t in temp.Requires)
    	    {
    	        if (_components.Exists(x => x.GetType() == t)) return null;
    	    }
    	    _components.Add(new T());
    	    temp.gameObject = this;
    	    return temp;
    	}
   		//...
	}
