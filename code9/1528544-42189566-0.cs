	public class PersonCollection : IList<IPerson>
	{
        private readonly List<IPerson> innerList = new List<IPerson>();
 
        // add interface methods
        public async Task AddAsync(IPerson person)
        {
            // your async add implementaion
        }
		public Person RemoveByMaxOf<T>(Func<IPerson, T> propertySelector) where T : IComparable
		{			
			if (Count == 0) return null;
			IPerson found = innerList0];
			T max = propertySelector(found);
			foreach (Person person in innerList.Skip(1))
			{
				T current = propertySelector(person);
				if (current.CompareTo(max) <= 0) continue;
				found = person;
				max = current;
			}
			innerList.Remove(found);
			return found;
		}
	}
    
