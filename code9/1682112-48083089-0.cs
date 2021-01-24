     var myPerson = new Person()
            {
                Name = "Eric",
                Addresses = new List<Address>()
                {
                    new Address() {Address1 = "123 First Street"}
                }
            };  
    var property = typeof(Person).GetProperty("Addresses");
    var addresses = (IList<Address>) property.GetValue(myPerson );
