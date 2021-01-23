    public class Program
    {
        static void Main(string[] args)
        {
           Del invoker = null;
           invoker += new Del(Display); //error!
        }
            
        static void Display(int a, int b)
        {
    
        }
    }
