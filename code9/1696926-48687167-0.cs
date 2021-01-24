      public bool ShouldSerializeFirstName(){  
        return 
           HttpContext.Request.Query["fields"]
               .ToString()
               .Split(",")
               .Contains("FirstName");
      }
