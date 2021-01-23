    class Program
        {
            static void Main(string[] args)
            {
                string valueout="cat";
                SetString1(10, ref valueout);
            }
            static void SetString1(int value_IN,ref string value_OUT)
            {
                if (value_OUT == "cat") 
                {
                    Console.WriteLine("Is cat");
                }
                value_OUT = "dog"; 
            }
    
    
        }
