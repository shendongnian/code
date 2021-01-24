    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                Foo();
            }
    
            private static void Foo()
            {
                // init new object
                Person p1 = new Person { age = 55, Name = "jonat8han" };
                Person p2 = new Person { age = 55, Name = "jonat#han" };
                Person p3 = new Person { age = 55, Name = "jonathan" };
    
                if (p1.IsWarning())
                {
                    Console.WriteLine("there is a digit...");
                    Console.ReadLine();
                    // write here some logic to do somthing with this....
                }
    
                if (p2.IsError())
                {
                    Console.WriteLine("there is a special char...");
                    Console.ReadLine();
                    // write here some logic to do somthing with this....
                }
    
                if (p3.IsWarning())
                {
                    // everything is OK
                }
            }
        }
    
        class Person
        {
            public string Name;
            public int age;
    
    
            public bool IsWarning()
            {
                // check if there are digits...
                Regex reg = new Regex("\\d");
                if (reg.IsMatch(this.Name) == true)
                {
                    // there is digit 
                    return true;
                }
                else
                {
                    return false;
                }
    
            }
    
            public bool IsError()
            {
                string[] speacialChars = new string[] { "*", "&", ".", "^", "#", "@" }; // define here what is a special character for your needs
                foreach (Char c in this.Name)
                {
                    if (speacialChars.Contains(c.ToString()))
                    {
                        return true;
                    }
                }
    
                return false;
            }
    
        }
    }
