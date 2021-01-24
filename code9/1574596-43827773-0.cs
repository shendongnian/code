    public static void Main(string[] args)
            {
    			var interpreter = new Interpreter();
                var result = interpreter.Eval("4975 + 10 * (LOG(250.6)) - 321.2".Replace("LOG", "Math.Log"));
    
                Console.WriteLine("result=> " + result);
                Console.ReadKey();
            }
