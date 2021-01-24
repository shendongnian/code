    public class X
    {
        public int value;
    }
    public class Point
    {
        public X x1;
    }
    void Main()
    {
        X x2 = new X();
        Point p = new Point();
        p.x1 = x2;
        x2.value = 50;
        Console.WriteLine(p.x1.value); //Prints out 50
    }
