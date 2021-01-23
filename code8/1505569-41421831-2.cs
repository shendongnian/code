    var castleBlack = new Address {City = "Castleblack", Status = statusActive};
    var personWithAddresses = new Person()
    {
            Name = "Jon SNOW",
            Status = statusActive,
            AddressCollection = new List<Address>()
            {
                castleBlack,
                new Address() { City = "Winterfel", 
                                Status = statusArchive }
            }    
    };
