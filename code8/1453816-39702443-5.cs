    IList<CarResult> carResults = new List<CarResult>();
    for (int i = 0; i < cars.Count(); i++)
    {              
        var result = new CarResult(); // Will not be accessible outside of loop.
        result = calculation.RunForCar(
            engineSize[i],
            yearOfManufacture[i]); // Fixed type-o?
        carResults.Add(result);
    }
    return carResults;
