    class Abc{
        int globalX;
        int globalY;
    ....
    public void functionone(int x, int y)
    {
       globalX = 1 + x;
       globalY = 2 + y;
    }
    
    public void functiontwo(int a , int b )
    {
       a=globalX + globalY;
       b=globalX - globalY;
    
       Console.WriteLine(a);
       Console.WriteLine(b);
    }
    
    }
