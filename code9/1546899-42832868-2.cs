    public static TResult AskForInput<TResult>(string message)
    {
        bool isValid = false;
        while(!isValid)
        {
            Console.WriteLine(message);
            string value = Console.ReadLine();
            try
            {   
                TResult result = (TResult)Convert.ChangeType(value, typeof(TResult));
                return result;
            }
            catch
            {
                Console.WriteLine("Input does not match requested type");
            }
        }
    }
