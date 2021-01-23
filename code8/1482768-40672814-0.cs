    using System;
    class Program
    {
        public static string playerName = "GARRET";
        // This will be concatonated to 1 string on runtime "* GARRET huh? \m That's a nice name."
        public static volatile string cutscene_introHurt7 = "* " + playerName + " huh?\n  That's a nice name.";
    
        static void Main(string[] args)
        {
            // We write the intended string
            Console.WriteLine(cutscene_introHurt7);
            // We change the name, but the string is still compiled
            playerName = "Hello world!";
            // Will give the same result as before
            Console.WriteLine(cutscene_introHurt7);
            // Now we overwrite the whole static variable
            cutscene_introHurt7 = "* " + playerName + " huh?\n  That's a nice name.";
            // And you do have the expected result
            Console.WriteLine(cutscene_introHurt7);
            Console.ReadLine();
        }
    }
