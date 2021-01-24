    // Read the file as one string.
                    string text = System.IO.File.ReadAllText(@"C:\WriteText.txt");
    
           // Display the file contents to the console. Variable text is string.
                    System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
    
        // Read each line of the file into a string array. 
        // Each element of the array is one line of the file.
                 string[] lines = System.IO.File.ReadAllLines(@"C:\WriteLines2.txt");
                
                        // Display the file contents by using a foreach loop.
                        System.Console.WriteLine("Contents of WriteLines2.txt = ");
                        foreach (string line in lines)
                    {
                        // Use a tab to indent each line of the file.
                        Console.WriteLine("\t" + line);
                    }
                    // Keep the console window open in debug mode.
                     Console.WriteLine("Press any key to exit.");
                     System.Console.ReadKey();
