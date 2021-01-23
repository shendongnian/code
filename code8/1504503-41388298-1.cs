    using System.Linq.Expressions;
    using System.Reflection;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using AutoMapper.QueryableExtensions.Impl;
    
    class NullableExpressionBinderEx : IExpressionBinder
    {
    	public static void Install()
    	{
    		var bindersField = typeof(ExpressionBuilder).GetField("Binders", BindingFlags.NonPublic | BindingFlags.Static);
    		var binders = (IExpressionBinder[])bindersField.GetValue(null);
    		binders[0] = new NullableExpressionBinderEx();
    	}
    	IExpressionBinder baseBinder = new NullableExpressionBinder();
    	private NullableExpressionBinderEx() { }
    	public bool IsMatch(PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionResolutionResult result)
    	{
    		if (propertyTypeMap != null && propertyTypeMap.CustomProjection != null)
    			return false;
    		return baseBinder.IsMatch(propertyMap, propertyTypeMap, result);
    	}
    	public MemberAssignment Build(IConfigurationProvider configuration, PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount)
    	{
    		return baseBinder.Build(configuration, propertyMap, propertyTypeMap, request, result, typePairCount);
    	}
    }
