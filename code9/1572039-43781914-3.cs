        static void Main(string[] args)
        {   
                bool myOutDemo(string str, out int result)
                {
                        result = (str??"").Length;
                        return result > 0;
                }
                // discard out parameter
                if (myOutDemo("123", out _)) Console.WriteLine("String not empty"); 
        }
