    using System;
    namespace HelloWorld
    {
        class Hello
        {
            static void Main()
            {
                Console.WriteLine("Hello World!");
                using (var client = new HttpClient())
                {
                    for (...) { ... }  // A really long loop
                    // Or you may even somehow start a daemon here
                }
                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
