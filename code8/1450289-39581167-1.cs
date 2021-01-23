    class CarComparer : IComparer<Car>
    {
        private int _sortModel;
        public CarComparer(int sortModel)
        {
            _sortModel = sortModel;
        }
        public int Compare(Car car1, Car car2)
        {
            if (car1.IsLuxury)
                return car2.IsLuxury ? 0 : -1;
            else if (car2.IsLuxury)
                return 1;
            if (car1.ModelId == _sortModel)
                return car2.ModelId == _sortModel ? 0 : -1;
            return car2.ModelId == _sortModel ? 1 : 0;
        }
    }
