    class CarComparer : IComparer<Car>
    {
        int Compare(Car car1, Car car2)
        {
            if (car1.IsLuxury)
                return car2.IsLuxury ? 0 : -1;
            if (car1.ModelId == 1)
                return car2.ModelId == 1 ? 0 : -1;
            return car2.ModelId == 1 ? 1 : 0;
        }
    }
