    public class PersonRepository
    {
     private readonly DBContext _myContext'
     public PersonRepository(DBContext myContext)
     { 
       _myContext = myContext; //<== Dependency INjection 
      }
      public function Person GetBySSN(int ssn)
      {
        return _myContext.FirstOrDefault(p => p.ssn = ssn);
       }
     }
