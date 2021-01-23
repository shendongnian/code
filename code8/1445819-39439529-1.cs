    public class E : A.B
    {
       public override void somethingCool(int[] val)
       {
          for (int i = val.Length - 1; i >= 0; --i)
          {
             System.Console.Write(string.Format("{0} ", val[i]));
          }
       }
    }
