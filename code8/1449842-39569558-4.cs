    public class Helper<T>
    {
       public void HelperMethod(Func<T,A> input,Func<T,B> input1,T t1)
       {            
          A a = input(t1);
          B b = input1(t1);
       }
    }
