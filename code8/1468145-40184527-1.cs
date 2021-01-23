    public interface IPart
    {
    }
    public class GG<T> where T : IPart
    {
        T GetSomething(string name);
    }
    public class PQR : IPart
    {
    }
    public class XYZ : GG<PQR>
    {
        PQR part;
        public PQR GetSomething(string name)
        {
            return part;
        }
    }
    public class HIJ : IPart
    {
    }
    public class ABC : GG<HIJ>
    {
        HIJ part;
        public HIJ GetSomething(string name)
        {
            return part;
        }
    }
