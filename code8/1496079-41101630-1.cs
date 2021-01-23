        public IEnumerable<Record[]> GetRecordsInRange(DateTime startDate, DateTime endDate)
		{
			while(startDate <= endDate)
			{
				// This hard-coded stuff should be replaced with something prettier but that's off topic and comes down to your implementation and the meaning of QueryTypes
				// I choose to isolate it to the delegates variable to make it easy to rewrite and perhaps instantiate it from a function
				var delegates = new Func<Record[]>[] 
				{
					()=>ExecuteQueryAPI(startDate, QueryTypes.A),
					()=>ExecuteQueryAPI(startDate, QueryTypes.B),
					()=>ExecuteQueryAPI(startDate, QueryTypes.C)
				};
				foreach(var d in delegates)
				{
					Record[] output;
					try
					{
						output = d();
					}
					catch
					{
						yield break;
					}
					yield return output;
				}
				startDate = startDate.AddDays(1);
			}
		}
