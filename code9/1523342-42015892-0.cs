    public class Program
    {
        private static readonly IEnumerable<Address> Addresses = new List<Address>
        {
            new Address{ Number = "1000", Direction = "North", Street = "Grand" },
            new Address{ Number = "2000", Direction = "North", Street = "Broadway" },
            new Address{ Number = "1000", Direction = "South", Street = "Main" },
            new Address{ Number = "3000", Direction = "South", Street = "Grand" },
            new Address{ Number = "2000", Direction = "East", Street = "Broadway" },
        };
        static void Main()
        {
            const string streetToMatch = "Broadway";
            const string numberToMatch = "2000";
            const string directionToMatch = "South";
            var rankedAddresses = from address in Addresses
                                  let streetRank = address.Street == streetToMatch ? 1 : 0
                                  let numberRank = address.Number == numberToMatch ? 1 : 0
                                  let directionRank = address.Direction == directionToMatch ? 1 : 0
                                  let rank = streetRank + numberRank + directionRank
                                  orderby rank descending
                                  select new
                                  {
                                      Address = address,
                                      Rank = rank
                                  };
            foreach (var rankedAddress in rankedAddresses)
            {
                var rank = rankedAddress.Rank;
                var address = rankedAddress.Address;
                Console.WriteLine($"Rank: {rank} | Address: {address.Number} {address.Direction} {address.Street}");
            }
        }
    }
    public class Address
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Direction { get; set; }
    }
