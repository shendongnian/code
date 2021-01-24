	class Program
	{
		static string[] arr;
		static Dictionary<int, int>[] hashes = new Dictionary<int, int>[1]
        { new Dictionary<int, int>() }
        ;
		static int[] file_indexes = {-1};
		static void AddHash(int hash, int index)
		{
			for (int h = 0; h < hashes.Length; h++)
			{
				Dictionary<int, int> dict = hashes[h];
				if (!dict.ContainsKey(hash))
				{
					dict[hash] = index;
					return;
				}
			}
			hashes = hashes.Union(new[] {new Dictionary<int, int>() {{hash, index}}}).ToArray();
			file_indexes = Enumerable.Range(0, hashes.Length).Select(x => -1).ToArray();
		}
		static int UpdateFileIndexes(int hash)
		{
			int updates = 0;
			for (int h = 0; h < hashes.Length; h++)
			{
				int index;
				if (hashes[h].TryGetValue(hash, out index))
				{
					file_indexes[h] = index;
					updates++;
				}
				else
				{
					file_indexes[h] = -1;
				}
			}
			return updates;
		}
		static bool IsDuplicate(int index)
		{
			string str1 = arr[index];
			for (int h = 0; h < hashes.Length; h++)
			{
				int i = file_indexes[h];
				if (i == -1 || index == i) continue;
				string str0 = arr[i];
				if (str0 == null) continue;
				if (string.CompareOrdinal(str0, str1) == 0) return true;
			}
			return false;
		}
		
		static void Main(string[] args)
		{
			arr = File.ReadAllLines("file.txt");
			for (int i = 0; i < arr.Length; i++)
			{
				int hash = arr[i].GetHashCode();
				if (UpdateFileIndexes(hash) == 0) AddHash(hash, i);
				else if (IsDuplicate(i)) arr[i] = null;
				else AddHash(hash, i);
			}
			File.WriteAllLines("file2.txt", arr.Where(x => x != null));
			Console.WriteLine("DONE");
			Console.ReadKey();
		}
	}
