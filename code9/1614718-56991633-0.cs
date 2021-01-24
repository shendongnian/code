	public static class BindingObjectExtensions
	{
		private static MethodInfo _bindablePropertyGetContextMethodInfo = typeof(BindableObject).GetMethod("GetContext", BindingFlags.NonPublic | BindingFlags.Instance);
		private static FieldInfo _bindablePropertyContextBindingFieldInfo;
		private static FieldInfo _bindingExpressionFieldInfo = typeof(Binding).GetField("_expression", BindingFlags.NonPublic | BindingFlags.Instance);
		private static PropertyInfo _bindingExpressionPathPropertyInfo;
		private static FieldInfo _bindingExpressionWeakSourceFieldInfo;
		private static FieldInfo _bindingExpressionWeakTargetFieldInfo;
		public static Binding GetBinding(this BindableObject bindableObject, BindableProperty bindableProperty)
	    {
	        object bindablePropertyContext = _bindablePropertyGetContextMethodInfo.Invoke(bindableObject, new[] { bindableProperty });
	        FieldInfo propertyInfo = _bindablePropertyContextBindingFieldInfo = 
		        _bindablePropertyContextBindingFieldInfo ?? 
					bindablePropertyContext.GetType().GetField("Binding");
	        return propertyInfo?.GetValue(bindablePropertyContext) as Binding;
	    }
	    public static object GetBindingExpression(this Binding binding)
	    {
	        return _bindingExpressionFieldInfo.GetValue(binding);
	    }
	    public static string GetPath(this object bindingExpression)
	    {
	        PropertyInfo propertyInfo = _bindingExpressionPathPropertyInfo = 
		        _bindingExpressionPathPropertyInfo ?? 
					bindingExpression.GetType().GetProperty("Path", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
	        return (string) propertyInfo.GetValue(bindingExpression);
	    }
	    public static object GetSource(this object bindingExpression)
	    {
	        FieldInfo fieldInfo = _bindingExpressionWeakSourceFieldInfo = 
		        _bindingExpressionWeakSourceFieldInfo ?? 
					bindingExpression.GetType().GetField("_weakSource", BindingFlags.Instance | BindingFlags.NonPublic);
	        object source;
	        ((WeakReference<object>) fieldInfo.GetValue(bindingExpression)).TryGetTarget(out source);
			return source;
	    }
	    public static BindableObject GetTarget(this object bindingExpression)
	    {
	        FieldInfo fieldInfo = _bindingExpressionWeakTargetFieldInfo = 
		        _bindingExpressionWeakTargetFieldInfo ?? 
					bindingExpression.GetType().GetField("_weakTarget", BindingFlags.Instance | BindingFlags.NonPublic);
	        BindableObject target;
	        ((WeakReference<BindableObject>) fieldInfo.GetValue(bindingExpression)).TryGetTarget(out target);
			return target;
	    }
	}
