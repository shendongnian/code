    class Program
    {
       static void Main(string[] args)
        {
           Board d=new Board();
           Square s=new Square();
           s.m1(d);
        }
    }
    class Board
    {
       int x=10;
    }
    class Square
    {
        public void m1(Board a)
        {
          Console.WriteLine(a.x);
        }
      Console.ReadLine();
    }
     
          
    
