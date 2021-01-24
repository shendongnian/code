		Dict<string, List<int>> chains = new Dict<string, List<int>>();
		List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();
		pairs.Add(Tuple.Create<int, int>(1, 2));
		pairs.Add(Tuple.Create<int, int>(3, 4));
		pairs.Add(Tuple.Create<int, int>(3, 5));
		pairs.Add(Tuple.Create<int, int>(5, 6));
		pairs.Add(Tuple.Create<int, int>(10, 11));
		pairs.Add(Tuple.Create<int, int>(2, 3));
		foreach (Tuple<int, int> pair in pairs)
		{
			string foundChainId	   = String.Empty;
			string chainIdToRemove = String.Empty;
			foreach (string chainId in chains.Keys)
			{
				List<int> bitList = chains[chainId];
				bool hasPair1 = bitList.Contains(pair.Item1);
				bool hasPair2 = bitList.Contains(pair.Item2);
				if (hasPair1 || hasPair2)
				{
					foundChainId = chainId;
					if (hasPair1 != hasPair2) //One value was added
					{
						int value = (!hasPair1 ? pair.Item1 : pair.Item2);
						foreach (string chainMergeId in chains.Keys)
						{
							if (chains[chainMergeId].Contains(value))
							{
								chainIdToRemove = chainMergeId;
								bitList.AddRange(chains[chainMergeId]);
								break;
							}
						}
						if (chainIdToRemove == String.Empty) //If there's no merge, add the new one value
							bitList.Add(value);
					}
					break;
				}
			}
			if (chainIdToRemove != String.Empty)
				chains.Remove(chainIdToRemove);
			if (foundChainId == String.Empty)
			{
				foundChainId = Guid.NewGuid().ToString();
				chains.Add(foundChainId, new List<int>());
				chains[foundChainId].Add(pair.Item1);
				chains[foundChainId].Add(pair.Item2);
			}
		}
