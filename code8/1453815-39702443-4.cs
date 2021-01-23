    IList<CarResult> carResults = new List<CarResult>();
    for (int i = 0; i < cars.Count(); i++)
    {              
        result = new CarResult();
        result = calculation.RunForCar(
            engineSize[i],
            yearOfManufacture[i]); // Fixed type-o?
        carResults.Add(result);
    }
    return carResults;
