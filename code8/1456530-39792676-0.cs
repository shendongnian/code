    results = class1s.SelectMany(c => c.Class2s.Select(c2 => new Result()
			{
				Class1Id = c.Id,
				Name = c2.Name,
				Value = c2.Value,
			})).ToList();
