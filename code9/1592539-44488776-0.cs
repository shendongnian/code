    public class Class1
    {
     public Class1()
     {
     }
     public Class1(param1)
     {
     }
     public Class1(param1,param2)
     {
     }
     public Class1(param1,param2,param3)
     {
     }
     public static Class1 GetNew(param1,param2,param3)
     {
      if(param1 != null && param2!= null && param3!= null)
      {
        return new Class1(param1,param2,param3);
      }
      else if(param1 != null && param2!= null && param3== null)
      {
        return new Class1(param1,param2);
      }
      else if(param1 != null && param2 == null && param3== null)
      {
        return new Class1(param1);
      }
      else 
      {
        return new Class1();
      }
     }
    }
