    public class TempClass
    {
       int a;
       public int A
       {
           set { a = value; }
           get { return a; }
       }
       public TempClass() { }
       public TempClass(int t) { A = t; }
       public override string ToString()
       {
           return A.ToString();
       }
    }
