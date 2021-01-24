      public void ValidateCustomer(Customer customer){
          _validate(string value, string error){
               if(!string.IsNullOrWhitespace(value)){
                  // i can easily reference customer here
                  customer.ValidationErrors.Add(error);
                  ErrorLogger.Log(error);
                  throw new ValidationError(error);                   
               }
          }
          _validate(customer.FirstName, "Firstname cannot be empty");
          _validate(customer.LastName, "Lastname cannot be empty");
          ... on  and on... 
      }
