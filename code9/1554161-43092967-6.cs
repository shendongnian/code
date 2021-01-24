    public class Surface
    {
        // you can have time property here as well
        public double this[int i, int j]
        {
            get { return GetTemperatureValueFromDataSource(i,j); }
        }
    }
