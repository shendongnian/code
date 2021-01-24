     public class Triangle : Shape
     {
          public Triangle (int x, int y, int z, int a, int b) : base(x,y,z)
          {
              A = a;
              B = b;
          }
          public int A {get;}
          public int B {get;}
     }
