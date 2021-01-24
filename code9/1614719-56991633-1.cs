	public static class BindingObjectExtensions
	{
		private static MethodInfo _bindablePropertyGetContextMethodInfo = typeof(BindableObject).GetMethod("GetContext", BindingFlags.NonPublic | BindingFlags.Instance);
		private static FieldInfo _bindablePropertyContextBindingFieldInfo;
		private static FieldInfo _bindingExpressionFieldInfo = typeof(Binding).GetField("_expression", BindingFlags.NonPublic | BindingFlags.Instance);
		private static Type _bindingExpressionType;
		private static FieldInfo _bindingExpressionWeakTargetFieldInfo;
		public static Binding GetBinding(this BindableObject bindableObject, BindableProperty bindableProperty)
	    {
	        object bindablePropertyContext = _bindablePropertyGetContextMethodInfo.Invoke(bindableObject, new[] { bindableProperty });
	        FieldInfo propertyInfo = _bindablePropertyContextBindingFieldInfo = 
		        _bindablePropertyContextBindingFieldInfo ?? 
					bindablePropertyContext.GetType().GetField("Binding");
	        return propertyInfo?.GetValue(bindablePropertyContext) as Binding;
	    }
	    private static object getBindingExpression(this Binding binding)
	    {
	        return _bindingExpressionFieldInfo.GetValue(binding);
	    }
	    public static BindableObject GetTarget(this Binding binding)
	    {
			object bindingExpression = binding.getBindingExpression();
	        FieldInfo fieldInfo = _bindingExpressionWeakTargetFieldInfo = 
		        _bindingExpressionWeakTargetFieldInfo ?? 
					bindingExpression.GetType().GetField("_weakTarget", BindingFlags.Instance | BindingFlags.NonPublic);
	        BindableObject target;
	        ((WeakReference<BindableObject>) fieldInfo.GetValue(bindingExpression)).TryGetTarget(out target);
			return target;
	    }
	}
