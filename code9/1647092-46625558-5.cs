    public interface ICar
    {
        void Save(ICar car);
    }
    public class Car : ICar
    {
        public void Save(ICar car) { }
    }
    public class Van : ICar
    {
        public void Save(ICar car) { }
    }
