    public interface ITestInterface<in T>
    {
        void Method(IEnumerable<T> e);
        IEnumerable<T> GetMethod(); // illegal
    }
    public class Animal {}
    public class Lion : Animal [}
    public class Gnu : Animal {}
    ITestInterface<Animal> animals;
    ITestInterface<Lion> lions;
    ITestInterface<Gnu> gnus;
