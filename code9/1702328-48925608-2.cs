	var source = new List<Car>() {
		new Car { Model = "Model A" },
		new Car { Model = "Model B" },
		new Car { Model = "Model B" },
		new Car { Model = "Model B" },
		new Car { Model = "Model A" },
		new Car { Model = "Model A" }
	};
	
	var result = source.CollectAdjacentWithSameModel();
    // elsewhere	
	public static class EnumerableExtensions
	{
		public static IEnumerable<IEnumerable<Car>> CollectAdjacentWithSameModel(this IEnumerable<Car> source)
		{
			var lastModel = default(Car);
			List<Car> currentList = new List<Car>();
			var result = new List<List<Car>>();
	
			foreach (var model in source)
			{
				if (lastModel != null && model.Model != lastModel.Model)
				{
					result.Add(currentList);
					currentList = new List<Car>();
				}
				currentList.Add(model);
				lastModel = model;
			}
	
			if (currentList.Any())
			{
				result.Add(currentList);
			}
	
			return result;
		}
	}
	
	public class Car {
		public string Model { get; set; }
	}
