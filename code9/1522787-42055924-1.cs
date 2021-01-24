    using System.Reflection;
    using System.Runtime.Serialization;
    public static object CustomMemberwiseClone(object source)
    {
    	var clone = FormatterServices.GetUninitializedObject(source.GetType());
    	for (var type = source.GetType(); type != null; type = type.BaseType)
    	{
    		var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    		foreach (var field in fields)
    			field.SetValue(clone, field.GetValue(source));
    	}
    	return clone;
    }
