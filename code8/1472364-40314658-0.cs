    public class Program
    {
        public static void Main()
        {
            dynamic offset = HandleOffset();
            
            Console.WriteLine(offset);
        }
    
        public static dynamic HandleOffset()
        {
            return new
            {
                Value = 64, 
                Offset = Offset.Cancel
            };
        }
    }
    
    public enum Offset
    {
        None = 0,
        Training = 10,
        Cancel = 20
    }
