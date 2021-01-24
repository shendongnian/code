    using System;
    
    namespace Bob
    {
        public interface IFather
        {
            string TypeName { get; }
            string OverridableTypeName { get; }
        }
    
        public class Son : IFather
        {
            public string TypeName { get; } = "Son";
            public virtual string OverridableTypeName { get; } = "Son";
        }
    
        public class Grandson : Son //, IFather
        {
            public string TypeName { get; } = "Grandson";
            public override string OverridableTypeName { get; } = "Grandson";
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                var son = new Son();
    
                Console.WriteLine(son.TypeName);
                Console.WriteLine(son.OverridableTypeName);
                Console.WriteLine(((IFather)son).TypeName);
                Console.WriteLine(((IFather)son).OverridableTypeName);
    
                var grandson = new Grandson();
    
                Console.WriteLine(grandson.TypeName);
                Console.WriteLine(grandson.OverridableTypeName);
                Console.WriteLine(((Son)grandson).TypeName);
                Console.WriteLine(((Son)grandson).OverridableTypeName);
                Console.WriteLine(((IFather)grandson).TypeName);
                Console.WriteLine(((IFather)grandson).OverridableTypeName);
    
                Console.ReadLine();
            }
        }
    }
