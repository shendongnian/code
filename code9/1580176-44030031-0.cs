		private static IEnumerable<List<Ricerca>> GetAllCombos(IReadOnlyCollection<Ricerca> list)
		{
			var comboCount = (int)Math.Pow(2, list.Count) - 1;
			for (var i = 1; i < comboCount + 1; i++)
			{
				// make each combo here
				yield return list.Where((t, j) => (i >> j) % 2 != 0).ToList();
			}
		}
