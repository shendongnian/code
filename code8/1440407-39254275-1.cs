    public static class CarExtensions
    {
        public static void Install(this Car car, Feature feature)
        {
            feature.Install(car);
        }
    }
