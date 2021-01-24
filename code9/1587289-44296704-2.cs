		MethodInfo miCreateDelegate = typeof(MethodInfo).GetMethod("CreateDelegate", new[] { typeof(Type), typeof(Object) });
		var ActionType = typeof(Action<>).MakeGenericType(MsgType);
		var lambdabody = Expression.Convert(Expression.Call(Expression.Constant(AnotherFunc), miCreateDelegate, new[] { Expression.Constant(ActionType), Expression.Constant(null) }), ActionType);
		var intparm = Expression.Parameter(typeof(int));
		var lambda = Expression.Lambda(lambdabody, intparm);
		CallEvent.Invoke(null, new object[] {
			lambda.Compile(),
			msg
		});
