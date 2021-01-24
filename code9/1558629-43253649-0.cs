     private static string MyName = "";
     ...
     public static void Introduction{
        Console.WriteLine("Welcome");
        Console.Write("What's your name ? : ");
        MyName = Console.ReadLine();
        Console.WriteLine("Hey {0},welcome to the quiz! ", MyName);
        Console.ReadLine();
     }
     
     ...
     public static void FstQuestion() {
       //code
       if (...) {
         Console.WriteLine(" That's correct,{0} ! ",MyName);
       }
       else
         Console.WriteLine(" Keep trying,{0} ",MyName);
       ... 
