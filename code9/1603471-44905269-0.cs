    var lst = new List<SomeObject>();
	var obj = lst;
	var type = obj.GetType();
	var ilistType = typeof(IList<>);
	if(type == ilistType || type.GetInterfaces().Any(c=>c.IsGenericType && c.GetGenericTypeDefinition() == ilistType)){
	Console.WriteLine("object is a list");
	// code here
	}
