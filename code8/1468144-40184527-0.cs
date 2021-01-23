    public interface IPart
    {
    }
    public interface ICanGet
    {
        IPart GetSomething(string name);
    }
    public class PQR : IPart
    {
    }
    public class XYZ : ICanGet
    {
        PQR part;
        public PQR GetSomething(string name)
        {
            return part;
        }
        IPart ICanGet.GetSomething(string name)
        {
            return GetSomething(name);
        }
    }
    public class HIJ : IPart
    {
    }
    public class ABC : ICanGet
    {
        HIJ part;
        public HIJ GetSomething(string name)
        {
            return part;
        }
        IPart ICanGet.GetSomething(string name)
        {
            return GetSomething(name);
        }
    }
