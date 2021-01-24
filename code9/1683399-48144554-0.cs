     public class RootObject
      {
            public int dateNumeric { get; set; }
            public int hourOfDay { get; set; }
            public int customerNumber { get; set; }
            public List<Storedepartment> storedepartment { get; set; }
      }
    
      public class Storedepartment
      {
            public int department { get; set; }
            public string descriptionOfDepartment { get; set; }
      }
