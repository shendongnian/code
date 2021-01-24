    using System.Collections.Generic;
    using System.Linq;
    
    internal class Program
    {
        public class OT_Contact
        {
            public int Age;
            public string Email;
            public string Name;
    
            public OT_Contact(string name, string email, int age = int.MinValue)
            {
                Name = name;
                Email = email;
                Age = age;
            }
    
            public override string ToString()
            {
                return ($"{Name} {Email} " + (Age != int.MinValue ? Age.ToString() : "")).Trim();
            }
        }
    
        static void Main(string[] args)
        {
            var owner = new List<OT_Contact>
                {
                    new OT_Contact("paul","p@o", 5),
                    new OT_Contact("paul","pppp@o"),
                    new OT_Contact("mani","kkk"),
                    new OT_Contact("olaf", "olaf", 22)
                };
    
            var borr = new List<OT_Contact>
                {
                    new OT_Contact("paul","popel@o", 5),
                    new OT_Contact("paul","pppp@o"),
                    new OT_Contact("mani","kkk",99),
                    new OT_Contact("olaf", "", 22)
                };
    
            var trust = owner.Where(o => !borr.Any(b => b.Name == o.Name && b.Email == o.Email)).ToList();
    
            System.Console.WriteLine("Owner:\n    " + string.Join("\n    ", owner));
            System.Console.WriteLine("\nBorrower:\n    " + string.Join("\n    ", borr));
            System.Console.WriteLine("\nTrustys:\n    " + string.Join("\n    ", trust));
    
            System.Console.ReadLine();
        }
    }
