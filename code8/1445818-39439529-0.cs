    public abstract class A
    {
       public string varA = "Default";
       public abstract class B
       {
          public B() {}
          public abstract void somethingCool(int[] val);
       }
    
       public void Foo(B bar, int[] val)
       {
          bar.somethingCool(val);
       }
    }
    
    public class C : A
    {
       // set B functions
       public class D : A.B
       {
          public override void somethingCool(int[] val)
          {
             for (int i = 0; i < val.Length; ++i)
             {
                System.Console.Write(string.Format("{0} ", val[i]));
             }         
          }
       }
    }
