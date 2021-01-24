      public void ValidateCustomer(Customer customer){
          if( string.IsNullOrEmpty( customer.FirstName )){
               string error = "Firstname cannot be empty";
               customer.ValidationErrors.Add(error);
               ErrorLogger.Log(error);
               throw new ValidationError(error);
          }
          if( string.IsNullOrEmpty( customer.LastName )){
               string error = "Lastname cannot be empty";
               customer.ValidationErrors.Add(error);
               ErrorLogger.Log(error);
               throw new ValidationError(error);
          }
          ... on  and on... 
      }
