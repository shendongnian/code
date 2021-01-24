	public object[] SelectByPredicate<T>(Func<T, bool> predicate)
	{
		if (typeof(T) == typeof(Person))
		{
			Func<Person, bool> f = (Person p) => 
			{
				T t	= (T)Convert.ChangeType(p, typeof(T));
				return predicate(t);
			};
			return this.SelectPersonsByPredicate(f);
		}
		else if (typeof(T) == typeof(Pet))
		{
			Func<Pet, bool> f = (Pet p) => 
			{
				T t	= (T)Convert.ChangeType(p, typeof(T));
				return predicate(t);
			};
			return this.SelectPetsByPredicate(f);
		}
		else
		{
			throw new NotSupportedException("Type not supported");
		}
	}
	
	private Person[] SelectPersonsByPredicate(Func<Person, bool> predicate)
	{
		return this.collectionPersons.AsQueryable().Where(predicate).ToArray();
	}
	private Pet[] SelectPetsByPredicate(Func<Pet, bool> predicate)
	{
		return this.collectionPets.AsQueryable().Where(predicate).ToArray();
	}
	
