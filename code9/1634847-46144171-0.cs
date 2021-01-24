    public IEnumerable<Car> practice_example6(List<Car> cars)
    {
        return cars != null ? 
            cars.Where(x => x.Make.IndexOf("honda", StringComparison.OrdinalIgnoreCase) != -1 ||
                            x.SuggestedRetailPrice < 3000) :
            Enumerable.Empty<Car>(); //Or null, depending what you prefer
    }
