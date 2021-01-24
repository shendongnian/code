    public static ValueTask<T[]> WhenAll<T>(IEnumerable<ValueTask<T>> tasks)
		{
			var list = tasks.ToList();
			var length = list.Count;
			var result = new T[length];
			var i = 0;
			for (; i < length; i ++)
			{
				if (list[i].IsCompletedSuccessfully)
				{
					result[i] = list[i].Result;
				}
				else
				{
					return WhenAllAsync();
				}
			}
			return new ValueTask<T[]>(result);
			async ValueTask<T[]> WhenAllAsync()
			{
				for (; i < length; i ++)
				{
					try
					{
						result[i] = await list[i];
					}
					catch
					{
						for (i ++; i < length; i ++)
						{
							try
							{
								await list[i];
							}
							catch
							{
								// ignored
							}
						}
						throw;
					}
				}
				return result;
			}
		}
