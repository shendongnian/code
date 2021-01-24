	public class C
	{
		public int Id { get; set; }
		private virtual A _a;
		public virtual A A
		{
			get
			{
				return _a;
			}
			set
			{
				if (value != null && _b != null)
					throw new ConstraintException("You can either have A or B; make up your mind!");
					
				if (value != _a)
					_a = value;
			}
		}
		
		private virtual B _b;
		public virtual B B
		{
			get
			{
				return _b;
			}
			set
			{
				if (value != null && _a != null)
					throw new ConstraintException("You can either have A or B; make up your mind!");
					
				if (value != _b)
					_b = value;
			}
		}
	}
