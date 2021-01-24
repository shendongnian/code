    class Engine
	{
		public void Execute(Action action)
		{
			var attr = action.Method.GetCustomAttributes(typeof(MyAttribute), true).First() as MyAttribute;
			var method1 = action.Target.GetType().GetMethod(attr.PreAction);
			var method2 = action.Target.GetType().GetMethod(attr.PostAction);
    
            // now first invoke the pre-action method
			method1.Invoke(null, null);
            // the actual action
			action();
            // the post-action
			method2.Invoke(null, null);
		}
	}
	public class MyAttribute : Attribute
	{
		public string PreAction;
		public string PostAction;
	}
