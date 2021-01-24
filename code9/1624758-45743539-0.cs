    public abstract class Airplane
    {
    }
    public class F15 : Airplane
    {
    }
    public class F16 : Airplane
    {
    }
    public class B747 : Airplane
    {
    }
    public class AirplaneFactory<T> where T : Airplane, new()
    {
        public List<T> Inventory => new List<T>();
        public T Make() { return new T(); }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            var b747_factory = new AirplaneFactory<B747>();
            var a_b747 = b747_factory.Make();
            b747_factory.Inventory.Add(a_b747);
        }
    }
