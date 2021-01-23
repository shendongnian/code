	class Warehouse
	{
		private int radios, televisions, computers;
		public int Radios
		{
			get { return radios; }
			set { radios = value; }
		}
		public int Televisions
		{
			get { return televisions; }
			set { televisions = value; }
		}
		public int Computers
		{
			get { return computers; }
			set { computers = value; }
		}
		public Warehouse(int radios, int televisions, int computers)
		{
			this.radios = radios;
			this.televisions = televisions;
			this.computers = computers;
		}
		public Warehouse() : this(5, 5, 5) { }
	}
