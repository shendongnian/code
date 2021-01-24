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
    
                List<Person> p = new List<Person>();
                p.Add(p1);
                p.Add(p2);
                p.Add(p3);
    
                foreach (Person person in p)
                {
    
                    if (person.IsValid() == Person.Validation.IsWarning)
                    {
                        Console.WriteLine(person.Name + " has digit...");
                        Console.ReadLine();
                        // write here some logic to do somthing with this....
                    }
                    else if (person.IsValid() == Person.Validation.IsError)
                    {
                        Console.WriteLine(person.Name + " special char...");
                        Console.ReadLine();
                        // write here some logic to do somthing with this....
                    }
                    else if (person.IsValid() == Person.Validation.IsErrorAndWarning)
                    {
                        Console.WriteLine(person.Name + " special char and digit...");
                        Console.ReadLine();
                        // write here some logic to do somthing with this....
                    }
    
                    else
                    {
                        // everything IsOk
                    }
                }
    
            }
    
            class Person
            {
                public enum Validation
                {
                    IsWarning = 0,
                    IsError = 1,
                    IsErrorAndWarning = 2,
                    IsOk = 3
                }
                public string Name;
                public int age;
    
                public Validation IsValid()
                {
                    if (IsError() && IsWarning())
                    {
                        return Validation.IsErrorAndWarning;
                    }
                    else if (IsError())
                    {
                        return Validation.IsError;
                    }
    
                    else if (IsWarning())
                    {
                        return Validation.IsWarning;
                    }
    
                    else
                    {
                        return Validation.IsOk;
                    }
    
                }
    
    
                private bool IsWarning()
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
    
                private bool IsError()
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
    }
