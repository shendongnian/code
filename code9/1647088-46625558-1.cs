    public interface ICar
    {
        void Save(ICar car);
    }
    public class Car : ICar
    {
        public void Save(Car car) { }
    }
    public class Van : ICar
    {
        public void Save(Van car) { }
    }
