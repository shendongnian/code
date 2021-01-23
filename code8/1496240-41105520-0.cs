     public static void Main (string[] args)
     {
       List<string> result = ExecuteCommand("sudo nginx -t");
       foreach (string output in result)
       {
         Console.WriteLine(output); 
       }
     }
