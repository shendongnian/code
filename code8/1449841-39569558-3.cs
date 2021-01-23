    public class Helper<T> where T:ICustom
    {
       public void HelperMethod(T input)
       {            
          A a = input.Method1();
          B b = input.Method2();
       }
    }
    interface ICustom
    {
       A Method1();
       B Method2();     
    }
    
    Class A
    {
      // Fields and Properties of Class A
    }   
    Class B
    {
      // Fields and Properties of Class B
    }    
