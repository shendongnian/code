	class TakeDamageHamster<T> where T : IHamster   // <-- same constraint 
	{
		public TakeDamageHamster(IHamster Hamster)//<-- now this is compatible with constraint alone, no matter what T is.
		{
			Console.WriteLine(Hamster.Some);
		}
	}
