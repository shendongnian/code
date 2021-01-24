	static void GetProperties(Type type, List<string> returnValue) {
		var props = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
		returnValue.AddRange(props.Select(p => p.Name).OrderBy(p => p));
	}
	private void MyMethod<T>(List<T> listData) where T : class {
		var type = typeof(T);
		List<string> properties = new List<string>();
		while (type != null) {
			GetProperties(type, properties);
			type = type.BaseType;
		}
	}
