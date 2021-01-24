    public static bool ShouldScaffoldColumn(PropertyInfo propertyInfo)
    {
    
    			return GetAttributeReturnValue<ScaffoldColumnAttribute, bool>(propertyInfo, (attr) => ((ScaffoldColumnAttribute)attr).Scaffold, true);
    		}
    
     /// <summary>
    		/// Calculate a return value from an attribute. See ShouldScaffoldColumn for example usage
    		/// </summary>
    		/// <typeparam name="T"></typeparam>
    		/// <param name="propertyInfo"></param>
    		/// <param name="eval">Function to use when evaluating the attribute's value to return a return value.</param>
    		/// <returns></returns>
    		private static T GetAttributeReturnValue<TAttr, T>(PropertyInfo propertyInfo, Func<object, T> eval, T valueWhenNotFound = null)
    		{
    
    			T returnValue = valueWhenNotFound;
    
    			var attrs = propertyInfo.GetCustomAttributes(typeof(TAttr), false);
    
    			if (!(attrs == null) && attrs.Length > 0)
    			{
    				var attr = attrs.First();
    
    				if (!(attr == null))
    				{
    					returnValue = eval(attr);
    				}
    			}
    
    			return returnValue;
    		}
    	}
