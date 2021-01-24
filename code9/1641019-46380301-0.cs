		public TPerson SetPerson<TPerson, TAddress>(string fn, string ln, string sl1, string sl2, string city, string prv, string cc) where TPerson : new() where TAddress : new()
		{
			var p = new TPerson();
			dynamic dp = p;
			
			dp.FirstName = fn;
			dp.LastName = fn;
			
			dynamic addr = new TAddress();
			dp.Address = addr;	
			addr.City = city;
		
			// ...
			
			return  p;
		}
    Then call like this:
        SetPerson<namespaceA.Person, namespaceA.Address>("1", "2", "3", "4", "5", "6", "7")
        SetPerson<namespaceB.Person, namespaceB.Address>("1", "2", "3", "4", "5", "6", "7")
