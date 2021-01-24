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
				if (value == null)
					throw new ArgumentNullException("A", "You must have A or B.");
					
				if (_b != null)
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
				if (value == null)
					throw new ArgumentNullException("B", "You must have A or B.");
					
				if (_a != null)
					throw new ConstraintException("You can either have A or B; make up your mind!");
				if (value != _b)
					_b = value;
			}
		}
		
		public class C(A a)
		{
			if (a == null)
				throw new ArgumentNullException("a");
			
			this._a = a;
		}
		
		public class C(B b)
		{
			if (b == null)
				throw new ArgumentNullException("b");
			
			this._b = b;
		}
		
		public SwitchBforA(A a)
		{
			if (a == null)
				throw new ArgumentNullException("a", "You'd end up with both A and B null.");
			
			_a = a;
			_b = null;
		}
		
		public SwitchAforB(B b)
		{
			if (b == null)
				throw new ArgumentNullException("b", "You'd end up with both A and B null.");
			
			_a = null;
			_b = b;
		}
	}
