			string[] arr = File.ReadAllLines("file.txt");
			HashSet<string> hashes = new HashSet<string>();
			for (int i = 0; i < arr.Length; i++)
			{
				if (!hashes.Add(arr[i])) arr[i] = null;
			}
			File.WriteAllLines("file2.txt", arr.Where(x => x != null));
