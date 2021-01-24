    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                B obj= new B();
                obj.print();
                Console.ReadKey();
            }
        }
    
        public class A
        {
            public virtual void print() { Console.WriteLine("a"); }
        }
        public class B : A
        {
            public override void print() 
            {
                base.print();
                Console.WriteLine("b"); 
            }
        }
    
    }
