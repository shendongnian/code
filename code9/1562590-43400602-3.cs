    public class Sites
    {
      //...
      public virtual ICollectio<Patient> Patients{get;set;}
      public Sites()
      { 
        Patients=new List<Patient>();
      }
    }
