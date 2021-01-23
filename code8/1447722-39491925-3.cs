	class A : IDynamicMetaObjectProvider
	{
		public dynamic this[string i] => this;
		public DynamicMetaObject GetMetaObject(Expression parameter) => new MetaObject(parameter, this);
		private class MetaObject : DynamicMetaObject
		{
			public MetaObject([NotNull] Expression expression, A value)
				: base(expression, BindingRestrictions.GetTypeRestriction(expression, typeof(A)), value)
			{
			}
			public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args) => this;
			public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes) => this;
		}
	}
	static void Main(string[] args)
	{
		A a = new A();
		a[""]("")[""][""]("");
		a[""][""](""); // should work as well
	}
	
