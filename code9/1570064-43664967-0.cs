    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                Address test = new Address();
                test.AddressId = 0;
                test.City = "xyzzzzzzzzzzzzzzz";
                test.streetName = "xyz";
                test.State = "xyzzzzzzzzzzzzzzzxxxxxxxxxxxxxxxxxxx";
    
                Person ptest = new Person
                {
                    PersonId = 1,
                    Name = "test1",
                    AddressInfo = test,
                    AddressId = 5,
                };
            }
        }
    
        public class Address
        {
            public int AddressId { get; set; }
            public string streetName { get; set; }
            public string City { get; set; }
            public string State { get; set; }
        }
        public class Person
        {
            public int PersonId { get; set; }
            public string Name { get; set; }
            public int AddressId { 
    
                get{ return AddressInfo != null ? AddressInfo.AddressId : 0;}
                set { AddressInfo.AddressId = value; }
        }
            public Address AddressInfo { get; set; }
        }
    }
