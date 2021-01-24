    private static void Main()
    {
        Console.Write("Some Text");           
        Console.Read(); //Console shows Show Text 
        MenuSystem.Controll(1, new List<string>() { "string" });
        Console.Read(); //Console shows string
    }
    
    ...
    class MenuSystem
    {
        public static void Controll(int count, List<String> texts)
        {
            Write(count, texts);
        }
    
        private static void Write(int index, List<String> texts) //I don't know why you are passing index as it is never used here.
        {
            Console.Clear(); //Console is now cleared
    
            foreach (String text in texts)
            {
                Console.WriteLine(text); 
            }
        }
    }
