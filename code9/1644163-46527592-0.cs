    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication3
    {
    interface IBase
    {
        void Function();
    }
    class BaseClass : IBase
    {
        public virtual void Function()
        {
        }
    }
    interface I1: IBase
    {
    }
    interface I2 : IBase
    {
    }
    class C1: BaseClass, I1
    {
        public override void Function()
        {
            Console.WriteLine("Hello from C1");
        }
    }
    class C2 : BaseClass, I1
    {
        public override void Function()
        {
            Console.WriteLine("Hello from C2 !!!");
        }
    }
    static class Generator
    {
        public static BaseClass generateC1()
        {
            return new C1();
        }
        public static BaseClass generateC2()
        {
            return new C2();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass b1 = Generator.generateC1();
            b1.Function();
            Console.WriteLine("-------");
            BaseClass b2 = Generator.generateC2();
            b2.Function();
            Console.WriteLine("End!");
        }
    }
    }
