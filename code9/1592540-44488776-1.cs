    public class Class2
    {
     public Class1(param1,param2,param3)
     {
      if(param1 != null && param2!= null && param3!= null)
      {
        Method1(param1,param2,param3);
      }
      else if(param1 != null && param2!= null && param3== null)
      {
        Method1(param1,param2);
      }
      else if(param1 != null && param2 == null && param3== null)
      {
        Method1(param1);
      }
      else 
      {
        Method1();
      }
     }
     public void Method1(param1,param2,param3)
     {
     }
     public void Method1(param1,param2)
     {
     }
     public void Method1(param1)
     {
     }
     public void Method1()
     {
     }
    }
