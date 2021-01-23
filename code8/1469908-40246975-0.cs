     set
     {
         if(string.IsNullOrEmpty(Value))
         {
             throw new ArgumentException("First name must not be blank!");
         }
         FirstName = Value;
     }
