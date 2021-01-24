	public static bool IsAutoProperty(this PropertyInfo prop)
	{
	    return prop.DeclaringType.GetFields(BindingFlags.NonPublic |BindingFlags.Instance).
               Any(p => p.Name.Contains("<" + prop.Name + ">"));
	}
