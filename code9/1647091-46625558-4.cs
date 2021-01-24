    public interface ICar
    {
        void Save(Car car);
    }
    public class Car : ICar
    {
        public void Save(Car car) { }
    }
    public class Van : ICar
    {
        // Here Van needs to have a Car object, why should it?
        public void Save(Car car) { }
    }
