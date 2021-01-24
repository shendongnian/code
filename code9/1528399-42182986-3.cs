    public static List<Car> getCarLot()
    {
        var trimList = getTrims();
        var colorList = getColors();
        var carLot = from m in getMakes()
                     select new Car {
                        colours = colorList.ToList(),
                        trims = trimList.ToList(),
                        make = m
                     };
        return carLot.ToList();
    }
