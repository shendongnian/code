    var bindingFlags = 
    ReflectionUtil.GetPrivatePropertyValue<BindingFlags>(propertyInfo, "BindingFlags");
            
            
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using HQ.Util.General.DynamicProperties;
    
    namespace HQ.Util.General.Reflection
    {
    	public class ReflectionUtil
    	{
    		// ******************************************************************
    		public static BindingFlags BindingFlagsAll = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
    		public static BindingFlags BindingFlagsPublic = BindingFlags.Public | BindingFlags.Instance;
    		public static BindingFlags BindingFlagsAllButNotStatic = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
    
    		// ******************************************************************
    		/// <summary>
    		/// Will also set public property. Will set value in instance of any base class in hierarchy.
    		/// </summary>
    		/// <param name="obj"></param>
    		/// <param name="propertyName"></param>
    		/// <param name="value"></param>
    		public static void SetPrivatePropertyValue(object obj, string propertyName, object value)
    		{
    			PropertyInfo pi = GetPropertyInfoRecursive(obj.GetType(), propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
    			if (pi == null)
    			{
    				throw new ArgumentOutOfRangeException(propertyName, string.Format("Property {0} was not found in Type {1}", propertyName, obj.GetType().FullName));
    			}
    			pi.SetValue(obj, value);
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// Will also get public property. Will get value in instance of any base class in hierarchy.
    		/// </summary>
    		/// <typeparam name="T"></typeparam>
    		/// <param name="obj"></param>
    		/// <param name="propertyName"></param>
    		/// <returns></returns>
    		public static T GetPrivatePropertyValue<T>(object obj, string propertyName)
    		{
    			PropertyInfo pi = GetPropertyInfoRecursive(obj.GetType(), propertyName);
    			if (pi == null)
    			{
    				throw new ArgumentOutOfRangeException(propertyName, string.Format("Property {0} was not found in Type {1}", propertyName, obj.GetType().FullName));
    			}
    
    			return (T)pi.GetValue(obj);
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// This is mainly used to look for private properties recursively because "FlattenHierarchy" is only applied on static members. 
    		/// And also because private property could only be gotten for declared class type, not hierarchy.
    		/// </summary>
    		/// <param name="type"></param>
    		/// <param name="propertyName"></param>
    		/// <param name="bindingFlags"></param>
    		/// <returns></returns>
    		public static PropertyInfo GetPropertyInfoRecursive(Type type, string propertyName, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
    		{
    			PropertyInfo pi = type.GetProperty(propertyName, bindingFlags);
    			if (pi == null && type.BaseType != null)
    			{
    				pi = GetPropertyInfoRecursive(type.BaseType, propertyName, bindingFlags);
    			}
    
    			return pi;
    		}
    		
