    static class Program
	{
		static void Main(string[] args)
		{
			List<Data> firstInstance = new List<Data>
			{
				new Data { Id = 1, IsActive = false },
				new Data { Id = 2, IsActive = false }
			};
			List<Data> secondInstance = new List<Data>
			{
				new Data { Id = 1, IsActive = false },
				new Data { Id = 3, IsActive = false }
			};
			firstInstance.CheckActive(secondInstance);
		}
		static void CheckActive(this List<Data> firstInstance, List<Data> secondInstance)
		{
			using (IEnumerator<Data> firstEnumerator = firstInstance.GetEnumerator(), secondEnumerator = secondInstance.GetEnumerator())
			{
				while (true)
				{
					if (!firstEnumerator.MoveNext() || !secondEnumerator.MoveNext()) break;
					if (firstEnumerator.Current.Id == secondEnumerator.Current.Id) firstEnumerator.Current.IsActive = true;
				}
			}
		}
	}
	class Data
	{
		public int Id { get; set; }
		public bool IsActive { get; set; }
	}
