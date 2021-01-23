     set
     {
         if(string.IsNullOrEmpty(value))
         {
             throw new ArgumentException("First name must not be blank!");
         }
         FirstName = value;
     }
