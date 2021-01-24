    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Reflection;
    
    namespace SandboxConsole
    {
    	public class ExpandoWrapper : DynamicObject
    	{
    		private readonly object _item;
    		private readonly Dictionary<string, PropertyInfo> _lookup = new Dictionary<string, PropertyInfo>(StringComparer.InvariantCulture);
    		private readonly Dictionary<string, PropertyInfo> _ignoreCaseLookup = new Dictionary<string, PropertyInfo>(StringComparer.InvariantCultureIgnoreCase);
    
    		private readonly Dictionary<string, Box> _lookupExtra = new Dictionary<string, Box>(StringComparer.InvariantCulture);
    		private readonly Dictionary<string, Box> _ignoreCaseLookupExtra = new Dictionary<string, Box>(StringComparer.InvariantCultureIgnoreCase);
    
    		private class Box
    		{
    			public Box(object item)
    			{
    				Item = item;
    			}
    			public object Item { get; }
    		}
    
    		public ExpandoWrapper(object item)
    		{
    			_item = item;
    			var itemType = item.GetType();
    			foreach (var propertyInfo in itemType.GetProperties())
    			{
    				_lookup.Add(propertyInfo.Name, propertyInfo);
    				_ignoreCaseLookup.Add(propertyInfo.Name, propertyInfo);
    			}
    		}
    		public override bool TryGetMember(GetMemberBinder binder, out object result)
    		{
    			result = null;
    			PropertyInfo lookup;
    			if (binder.IgnoreCase)
    			{
    				_ignoreCaseLookup.TryGetValue(binder.Name, out lookup);
    			}
    			else
    			{
    				_lookup.TryGetValue(binder.Name, out lookup);
    			}
    
    			if (lookup != null)
    			{
    				result = lookup.GetValue(_item);
    				return true;
    			}
    
    			Box box;
    			if (binder.IgnoreCase)
    			{
    				_ignoreCaseLookupExtra.TryGetValue(binder.Name, out box);
    			}
    			else
    			{
    				_lookupExtra.TryGetValue(binder.Name, out box);
    			}
    
    			if (box != null)
    			{
    				result = box.Item;
    				return true;
    			}
    
    			return false;
    		}
    
    		public override bool TrySetMember(SetMemberBinder binder, object value)
    		{
    			PropertyInfo lookup;
    			if (binder.IgnoreCase)
    			{
    				_ignoreCaseLookup.TryGetValue(binder.Name, out lookup);
    			}
    			else
    			{
    				_lookup.TryGetValue(binder.Name, out lookup);
    			}
    
    			if (lookup != null)
    			{
    				lookup.SetValue(_item, value);
    				return true;
    			}
    
    			var box = new Box(value);
    			_ignoreCaseLookupExtra[binder.Name] = box;
    			_lookupExtra[binder.Name] = box;
    
    			return true;
    		}
    	}
    }
