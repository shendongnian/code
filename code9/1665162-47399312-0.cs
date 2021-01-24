    using System;
    using System.Reflection;
    public class ProxyClass
	{
		public Type   WrappedType   { get; private set; }
		public Object WrappedObject { get; private set; }
		
		
		public ProxyClass(Object wrappedObject)
		{
			WrappedObject = wrappedObject;
			WrappedType   = wrappedObject.GetType();
			
		} // end constructor
		
		public object GetPropVal(String propName)
		{
			return WrappedType.GetProperty(propName).GetValue(WrappedObject, null);
		} // end GetPropVal
		
		public void SetPropVal(String propName, Object val)
		{
			WrappedType.GetProperty(propName).SetValue(WrappedObject, val, null);
		} // end SetPropVal
			
	}
