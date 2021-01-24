    public class Surface
    {
        public double this[int i, int j]
        {
            get { return GetTemperatureValueFromDataSourece(i,j); }
        }
    }
