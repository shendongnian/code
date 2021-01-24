	class AAdapter : ICommon
	{
		private readonly A inner;
		public Adapter(A inner)
		{
			if (inner == null)
				throw new ArgumentNullException(nameof(inner));
			this.inner = inner;
		}
		
		public string CommonProperty1 
		{
			get { return inner.CommonProperty1; }
			set { inner.CommonProperty1 = value; }
		}
		public int CommonProperty2
		{
			get { return inner.CommonProperty2; }
			set { inner.CommonProperty2 = value; }
		}
		public string CommonProperty3 
		{
			get { return inner.CommonProperty3; }
			set { inner.CommonProperty3 = value; }
		}
		public string CommonProperty4 
		{
			get { return inner.CommonProperty4; }
			set { inner.CommonProperty4 = value; }
		}
		public string CommonProperty5
		{
			get { return inner.CommonProperty5; }
			set { inner.CommonProperty5 = value; }
		}	
	}
	
	class BAdapter : ICommon
	{
		private readonly B inner;
		public Adapter(B inner)
		{
			if (inner == null)
				throw new ArgumentNullException(nameof(inner));
			this.inner = inner;
		}
		
		public string CommonProperty1 
		{
			get { return inner.CommonProperty1; }
			set { inner.CommonProperty1 = value; }
		}
		public int CommonProperty2
		{
			get { return inner.CommonProperty2; }
			set { inner.CommonProperty2 = value; }
		}
		public string CommonProperty3 
		{
			get { return inner.CommonProperty3; }
			set { inner.CommonProperty3 = value; }
		}
		public string CommonProperty4 
		{
			get { return inner.CommonProperty4; }
			set { inner.CommonProperty4 = value; }
		}
		public string CommonProperty5
		{
			get { return inner.CommonProperty5; }
			set { inner.CommonProperty5 = value; }
		}	
	}
	
	// Other similar adapters...
