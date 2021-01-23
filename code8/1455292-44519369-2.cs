	public class MyClassEqualityComparer : IEqualityComparer<MyClass>
	{
		private MyClassComparisonFields _Comparisons;
		
		public MyClassComparer(MyClassComparisonFields comparisons)
		{
			_Comparisons = comparisons;
		}
		
		public bool Equals(MyClass x, MyClass y)
		{
			if(ReferenceEquals(x, y))
				return true;
			
			if(ReferenceEquals(x, null))
				return false;
			
			if(ReferenceEquals(y, null))
				return false;
			
			if(_Comparisons.HasFlag(MyClassComparisonFields.First))
			{
				if(!EqualityComparer<int>.Default.Equals(x.First, y.First))
					return false;
			}
			
			if(_Comparisons.HasFlag(MyClassComparisonFields.Second))
			{
				if(!EqualityComparer<string>.Default.Equals(x.Second, y.Second))
					return false;
			}
			
			if(_Comparisons.HasFlag(MyClassComparisonFields.Third))
			{
				if(!EqualityComparer<decimal>.Default.Equals(x.Third, y.Third))
					return false;
			}
			
			return true;
		}
		
		public int GetHashCode(MyClass x)
		{
			if(ReferenceEquals(x, null))
				return 0;
			
			int hash = 97463;
			
			if(_Comparisons.HasFlag(MyClassComparisonFields.First))
			{
				hash = hash * 99713 + x.First.GetHashCode();
			}
			if(_Comparisons.HasFlag(MyClassComparisonFields.Second)
			   && x.Second != null)
			{
				hash = hash * 99713 + x.Second.GetHashCode();
			}
			if(_Comparisons.HasFlag(MyClassComparisonFields.Third))
			{
				hash = hash * 99713 + x.Third.GetHashCode();
			}
			return hash;
		}
	}
