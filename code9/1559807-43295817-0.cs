    public class Program
    {
    public static void Main()
    {
        try 
        {
            for(int i = 0;i<100;i++)
            {
                if(i == 10)
                {
                    break;
                }
                Console.WriteLine(i);
            }
        } 
        catch 
        {
            Console.WriteLine("Catch");
        }
        finally
        {
            Console.WriteLine("finally");
        }
    }
    }
