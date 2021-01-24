    private sealed class FooEqualityComparer : IEqualityComparer<Foo>
        {
    		private List<bool> comparisonResults = new List<bool>();
    		
            public bool Equals(Foo x, Foo y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
    			
    			int propertiesCount = typeof(Foo)
    					.GetProperties(BindingFlags.Public | BindingFlags.Instance)
    					//.Where(someLogicToExclude(e.g ignore attribute))
    					.Count();
    					
    			comparisonResults.Add(x.Int == y.Int);
    			comparisonResults.Add(string.Equals(x.Str, y.Str));
    			
    			bool propertiesMatch = comparisonResults.All(b => b);
    			bool hasNewProperty = comparisonResults.Count() != propertiesCount;
                return propertiesMatch && !hasNewProperty;
            }
    
            public int GetHashCode(Foo obj)
            {
                unchecked
                {
                    return (obj.Int * 397) ^ (obj.Str != null ? obj.Str.GetHashCode() : 0);
                }
            }
        }
