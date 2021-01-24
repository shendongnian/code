    List<Car> cars = new List<Car>();
    foreach (Type type in Enum.GetValues(typeof(Type)))
    {
        foreach (Size size in Enum.GetValues(typeof(Size)))
        {
            cars.Add(new Car() {Size = size, Type = type});
		}
    }
