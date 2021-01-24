			int x;
			var res = lines
				// filter out empty lines
				.Where(line => !string.IsNullOrEmpty(line))
				// convert ranges to pairs
				.Select(line => line.Split('-'))
				// filter out not numbers
				.Where(line => line.All(number => int.TryParse(number, out x)))
				// convert all strings to int
				.Select(item => item.Select(int.Parse).ToList())
				.SelectMany(item =>
				{
					if (item.Count > 1)
					{
						return Enumerable.Range(item[0], item[1] - item[0] + 1);
					}
					return item;
				})
				.ToList();
