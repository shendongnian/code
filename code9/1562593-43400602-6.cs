    public class Sites
    {
      //...
      public virtual ICollection<Patient> Patients{get;set;}
      public Sites()
      { 
        Patients=new List<Patient>();
      }
    }
