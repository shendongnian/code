    public class Input
    {
        public static void Write(string message)
        {
            Console.WriteLine(message);
        }
    
        public static int? ReadInt(string reason)
        {
            Write(reason);
            string userInput = Console.ReadLine();
            int parsed = 0;
            if(int.TryParse(userInput, out parsed))
                return (int?)parsed;
     
            return null;
        }
    }
