     private static String LastName(string value) {
       if (string.IsNullOrEmpty(value))
         return value;
       int p = value.LastIndexOf('.');
       return value.SubString(p + 1);  
     } 
     ...
     mylist.Sort((left, right) => string.Compare(LastName(left), LastName(right)));
