        public class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("I'm about to go into a method.");
    
                string result = DoSomethingAwesome();
    
                Console.WriteLine("I'm back from the method.");
            }
    
            static string DoSomethingAwesome()
            {
                return "I'm inside of a method, doing something awesome!";
            }
        }
