     public class ObjectPropertyHelper
     {
    		//Public Shared Iterator Function GetVisibleProperties(Of T)(Optional isVisible As Boolean = True) As IEnumerable(Of PropertyInfo)
    		//    GetVisibleProperties(GetType(T), isVisible)
    		//End Function
    		public static IEnumerable<PropertyInfo> GetVisibleProperties(Type type, bool isVisible)
    		{
    
    			var props = type.GetProperties();
    
    			for (var i = 0; i < props.Length; i++)
    			{
    				PropertyInfo propertyInfo = props[i];
    
    				if (propertyInfo.CanRead)
    				{
    					bool shouldScaffold = Annotations.ShouldScaffoldColumn(propertyInfo);
    					var x = props[i].Name;
    
    					if (shouldScaffold == isVisible)
    					{
    						yield return propertyInfo;
    					}
    
    				}
    			}
    
    		}
    
    
    	}
