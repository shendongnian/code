    public int practice_example6(List<Car> cars)
    {
        return cars == null ? 0 :
            cars.Count(x => x.Make.IndexOf("honda", StringComparison.OrdinalIgnoreCase) != -1 ||
                            x.SuggestedRetailPrice < 3000);
    }
