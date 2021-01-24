    using System;
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main(string[] args)
            {
                CustomDynamic f = new CustomDynamic();
                f.AddProperty("Name", "Hamiltonian Physics");
                Func<CustomDynamic, string> fn = Compiler.Compile<string>("CustomDynamic.GetString(\"Name\").SubString(0, 3)");
                string sub = fn(f);
                Console.WriteLine(sub);
                Console.ReadLine();
            }
        }
    }
