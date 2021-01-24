    static void Main(string[] args)
    {
       var x = 2;
       try
       {
           if(x >1) throw new Exception("Apple");
       }
       catch (Exception ex)
       {
           x = 1;
       }
       finally
       {
          Console.WriteLine("Carrot");
       }
    }
