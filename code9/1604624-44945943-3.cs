    private sealed class FooEqualityComparer : IEqualityComparer<Foo>
    {
		private List<bool> comparisonResults = new List<bool>();
		private List<Func<Foo, Foo, bool>> conditions = new List<Func<Foo, Foo, bool>>{
			(x, y) => x.Int == y.Int,
			(x, y) => string.Equals(x.Str, y.Str)
		};
		private int propertiesCount = typeof(Foo)
					.GetProperties(BindingFlags.Public | BindingFlags.Instance)
					//.Where(someLogicToExclde(e.g attribute))
					.Count();
		
        public bool Equals(Foo x, Foo y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;	
            //has new property which is not presented in the conditions list and not excluded
			if (conditions.Count() != propertiesCount) return false;	
			
			foreach(var func in conditions)
				if(!func(x, y)) return false;//returns false on first mismatch
			
            return true;//only if all conditions are satisfied
        }
        public int GetHashCode(Foo obj)
        {
            unchecked
            {
                return (obj.Int * 397) ^ (obj.Str != null ? obj.Str.GetHashCode() : 0);
            }
        }
    }
