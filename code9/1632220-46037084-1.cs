    public class DataService
    { 
       public MyClass RetriveData(string name)
       {
          var mydata = _context.Get(name);
          return mydata
       }
     }
