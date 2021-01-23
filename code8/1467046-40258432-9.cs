    class Program
    {        
        static void Main(string[] args)
        {
            Action<string> myAction = s =>
            {
                Console.WriteLine("Hello " + s);
            };
            MethodInfo method = myAction.GetMethodInfo();
            
            //Rest of your code
        }
    }
