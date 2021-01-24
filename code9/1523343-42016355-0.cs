       using System;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace mns
    {
    					
    public class Program
    {
    	 private static readonly IEnumerable<Address> Addresses = new List<Address>
        {
               new Address{ Number = "1234", Direction = "South", Street = "Main" },
    		 new Address{ Number = "1234", Direction = "North", Street = "Broadway" },
    		 new Address{ Number = "1234", Direction = "North", Street = "Grand" },
          
          
            new Address{ Number = "1234", Direction = "South", Street = "Broadway" },
            new Address{ Number = "34", Direction = "East", Street = "Broadway" },
        };
    
        public static void Main()
        {
            const string streetToMatch = "Broadway";
            const string numberToMatch = "1234";
            const string directionToMatch = "South";
    		var combinedAdrress = numberToMatch +" "+ streetToMatch + " "+ directionToMatch;
    
                        var rankedAddresses = from address in Addresses.Where(s=>numberToMatch== s.Number).Intersect(Addresses.Where(s=>directionToMatch==s.Direction)).Intersect(Addresses.Where(s=>streetToMatch == s.Street))
    						.Union(Addresses.Where(s=>numberToMatch== s.Number).Intersect(Addresses.Where(s=>streetToMatch == s.Street)))
    						.Union(Addresses.Where(s=>streetToMatch == s.Street))
                  
                                  select new
                                  {
                                      Address = address.Number + " " + address.Street+ " "+ address.Direction
                                      
                                  };
    		 Console.WriteLine("You are searching for: "+combinedAdrress);;
    
            foreach (var rankedAddress in rankedAddresses)
            {
                
                var address = rankedAddress.Address;
                Console.WriteLine(address);
            }
        }
    }
    
    public class Address
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Direction { get; set; }
    }
    }
