    public class Program
    {
        public static void Main(string[] args)
        {
            
            var values=GetNumbers(6,2);
            Console.Write(values);
          
            
        }
        
        static KeyValuePair<int,int> GetNumbers(int x,int y)
        {
            return new KeyValuePair<int,int>(x,y);
        }
    }
