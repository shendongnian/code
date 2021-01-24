		internal static MethodCallReturn<T, TResult> Setup<T, TResult>(
			Mock<T> mock,
			Expression<Func<T, TResult>> expression,
			Condition condition)
			where T : class
		{
			return PexProtector.Invoke(() =>
			{
				if (expression.IsProperty())
				{
					return SetupGet(mock, expression, condition);
				}
				var methodCall = expression.GetCallInfo(mock);
				var method = methodCall.Method;
				var args = methodCall.Arguments.ToArray();
				ThrowIfNotMember(expression, method);
				ThrowIfCantOverride(expression, method);
				var call = new MethodCallReturn<T, TResult>(mock, condition, expression, method, args);
				var targetInterceptor = GetInterceptor(methodCall.Object, mock);
				targetInterceptor.AddCall(call, SetupKind.Other);
				return call;
			});
		}
