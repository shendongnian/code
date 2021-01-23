    public class YourClass{
    
        private static string _input;
    
        public static void Main (string[] args)
        {
            Console.Write ("What is your name: ");
            _input = Console.ReadLine ();
    
            sayHi ();
        }
    
        public static string sayHi() {
            Console.WriteLine ("Hello {0}!", _input);
        }
    }
