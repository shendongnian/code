	public class CustomerVM { }
	public class Customer {}
	
	public class ReplaceMethodAttribute: Attribute
	{
		public string ReplacementMethodName {get; private set;}
		public ReplaceMethodAttribute(string name)
		{
			ReplacementMethodName = name;
		}
	}
	public static class Extensions
	{
		public static CustomerVM ToCustomerVM(Customer customer)
		{
			throw new NotImplementedException();
		}
		[ReplaceMethod("Extensions.ToCustomerVM")]
		public static CustomerVM ToVM(this Customer customer)
		{
			return Extensions.ToCustomerVM(customer);
		}
	}
	public class ReplaceMethodVisitor: ExpressionVisitor
	{
		protected override Expression VisitMethodCall(MethodCallExpression exp)
		{
			var attr = exp.Method.GetCustomAttributes(typeof(ReplaceMethodAttribute), true).OfType<ReplaceMethodAttribute>().FirstOrDefault();
			if (attr != null)
			{
				var parameterTypes = exp.Method.GetParameters().Select(i => i.ParameterType).ToArray();
				var mi = GetMethodInfo(attr.ReplacementMethodName, parameterTypes);
				return Visit(Expression.Call(mi, exp.Arguments));
			}
			return base.VisitMethodCall(exp);
		}
		
		private MethodInfo GetMethodInfo(string name, Type[] argumentTypes)
		{
			// enhance with input checking
			var lastDot = name.LastIndexOf('.');
			var type = name.Substring(0, lastDot);
			var methodName = name.Substring(lastDot);
			return this.GetType().Assembly.GetTypes().Single(x => x.FullName == type).GetMethod(methodName, argumentTypes); // this might need adjusting if types are in different assembly
		}
		
	}
