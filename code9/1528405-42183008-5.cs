    public static List<Car> getCarLot()
    {
        return makeList.Select(m => new Car
        {
            make = m,
            colours = colourList.ToList(),
            trims = trimList.ToList()
        });
    }
