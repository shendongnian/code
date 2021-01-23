	public static string GetPrettyName(this Type type)
	{
		var retval = type.Name;
		if (type.IsGenericType)
		{
			var genargNames = type.GetGenericArguments().Select(t => GetPrettyName(t));
			var idx = type.Name.IndexOf('`');
			var typename = (idx > 0) ? type.Name.Substring(0, idx) : type.Name;
			retval = String.Format("{0}.{1}<{2}>", type.Namespace, typename, String.Join(", ", genargNames));
		}
		else if (type.IsArray)
		{
			retval = GetPrettyName(type.GetElementType()) + "[]";
		}
		else if (String.IsNullOrEmpty(retval))
		{
			retval = type.Name;
		}
		return retval;
	}
