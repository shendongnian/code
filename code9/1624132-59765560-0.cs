    message Person {
      string PersonKey = 1;
      string FirstName = 2;
      string Surname=3;
      Address BillingAddress = 4;
    }
    
    message Address {
      string AddressKey = 1;
      string StreeNumber = 2;
      string Street=3;
      string Suburb=4;
    }
