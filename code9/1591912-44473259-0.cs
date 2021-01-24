		static Task<T[]> MergeSort<T>(T[] src) where T : IComparable<T>
		{
			if (src.Length <= 1)
			{
				return Task.FromResult(src);
			}
			else
			{
				int mid = src.Length / 2;
				T[] firstHalf = new T[mid];
				T[] secondHalf = new T[src.Length - mid];
				Array.Copy(src, 0, firstHalf, 0, mid);
				Array.Copy(src, mid, secondHalf, 0, src.Length - mid);
				Task<T[]> firstTask = Task.Run(() => MergeSort(firstHalf));
				Task<T[]> secondTask = Task.Run(() => MergeSort(secondHalf));
				return Task.WhenAll(firstTask, secondTask).ContinueWith(
					continuationFunction: _ =>
					{
						T[] firstDest = firstTask.Result;
						T[] secondDest = secondTask.Result;
						int firstIndex = 0;
						int secondIndex = 0;
						T[] dest = new T[src.Length];
						for (int i = 0; i < dest.Length; i++)
						{
							if (firstIndex >= firstDest.Length)
							{
								dest[i] = secondDest[secondIndex++];
							}
							else if (secondIndex >= secondDest.Length)
							{
								dest[i] = firstDest[firstIndex++];
							}
							else if (firstDest[firstIndex].CompareTo(secondDest[secondIndex]) < 0)
							{
								dest[i] = firstDest[firstIndex++];
							}
							else
							{
								dest[i] = secondDest[secondIndex++];
							}
						}
						return dest;
					},
					cancellationToken: System.Threading.CancellationToken.None,
					continuationOptions: TaskContinuationOptions.ExecuteSynchronously,
					scheduler: TaskScheduler.Default);
			}
		}
