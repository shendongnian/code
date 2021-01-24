    class Program
    {
        static void Main(string[] args)
        {
            Helper.Bar(new A());
        }
    }
    
    public class A : IFoo, IMap
    {
        public A()
        {
            Cs = new List<C> { new C(), new C() };
            Bs = new List<B> { new B(), new B() };
        }
        public void Foo()
        {
            Console.WriteLine("A");
        }
        public List<B> Bs { get; set; }
        public List<C> Cs { get; set; }
    
        public List<Func<dynamic, List<IFoo>>> Map()
        {
            return this.CreateMap()
                .Then(x => ((List<B>)x.Bs).ToList<IFoo>())
                .Then(x => ((List<C>)x.Cs).ToList<IFoo>());
        }
    
    }
    
    public class B : IFoo, IMap
    {
        public B()
        {
            Ds = new List<D> { new D(), new D() };
        }
        public void Foo()
        {
            Console.WriteLine("B");
        }
    
        public List<Func<dynamic, List<IFoo>>> Map()
        {
            return this.CreateMap()
                .Then(x => ((List<D>)x.Ds).ToList<IFoo>());
        }
    
        public List<D> Ds { get; set; }
    }
    
    public class C : IFoo, IMap
    {
        public void Foo()
        {
            Console.WriteLine("C");
        }
    
        public List<Func<dynamic, List<IFoo>>> Map()
        {
            return this.CreateMap();
        }
    }
    
    public class D : IFoo, IMap
    {
        public void Foo()
        {
            Console.WriteLine("D");
        }
    
        public List<Func<dynamic, List<IFoo>>> Map()
        {
            return this.CreateMap();
        }
    }
    
    public static class Mapper
    {
        public static List<Func<dynamic, List<IFoo>>> CreateMap(this IFoo item)
        {
            return new List<Func<dynamic, List<IFoo>>>();
        }
    
        public static List<Func<dynamic, List<IFoo>>> Then(this List<Func<dynamic, List<IFoo>>> list, Func<dynamic, List<IFoo>> expression)
        {
            list.Add(expression);
            return list;
        }
    }
    public class Helper
    {
        public static void Bar(dynamic obj)
        {
            obj.Foo();
            var map = obj.Map();
            if (map != null)
            {
                foreach(var item in map)
                {
                    var lists = item(obj);
                    foreach(var list in lists)
                    {
                        Bar(list);
                    }
                }
            }
        } 
    
    }
    
    public interface IFoo
    {
        void Foo();
    }
    
    public interface IMap 
    {
        List<Func<dynamic, List<IFoo>>> Map();
    }
