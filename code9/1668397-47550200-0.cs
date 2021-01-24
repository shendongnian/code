    using AutoMapper;
    using System;
    
    public class Program
    {
        public class Source : IFoo
        {
            public string Foo { get; set; }
        }
    
        public class Destination<T> : IGenericFoo<T> where T : class
        {
            public string Baboon { get; set; }
        }
    
        public interface IFoo
        {
            string Foo { get; set; }
        }
    
        public interface IGenericFoo<TDestination> where TDestination : class
        {
            string Baboon { get; set; }
        }
    
        public static void Main()
        {
            // Create the mapping
            Mapper.Initialize(cfg => cfg.CreateMap(typeof(Source), typeof(Destination<>)));
    
            var source = new Source { Foo = "foo" };
    
            var dest = Mapper.Map<Source, Destination<object>>(source);
    
            Console.WriteLine(dest.Baboon);
        }
    }
