    public class Context
    {
        public Apple[] Apples { get; set; }
        public IFruit[] GetFruits()
        {
            return null;
        }
    }
    public interface IFruit
    {
        
    }
    public class Apple : IFruit
    {
    }
    public class Banana : IFruit
    {
    }
    public static class Apples
    {
        public static void MakeAppleJuice(this Apple[] apples)
        {
        }
        public static void ProcessItem(this Apple[] apples, Apple fruit)
        {
        }
    }
    class Program
    {
        static void Foo(IFruit[] fruits)
        {
        }
        static void Main(string[] args)
        {
            var context = new Context();
            context.Apples.MakeAppleJuice();
            context.GetFruits();
            Foo(context.Apples); //Dangerous call, but legal.
            Foo(context.GetFruits());
            context.Apples.ProcessItem(new Banana()); // Does not compile.
        }
    }
