    using System;
    namespace caesarCipher
    {
        class Program
        {
            static void Main(string[] args)
            {
                string text;
                Console.WriteLine("Enter the text to encrypt ");
                text = System.Convert.ToString(Console.ReadLine());
                string lower = text.ToLower();
                Random rnd = new Random();
                int shift = rnd.Next(1, 25);
                // declare and initialize newText here
                string newText = string.Empty;
                foreach (char c in lower)
                {
                    int unicode = c;
                    int shiftUnicode = unicode + shift;
                    Console.WriteLine(shiftUnicode);
                    if (shiftUnicode >= 123)
                    {
                        int overflowUnicode = 97 + (shiftUnicode - 123);
                        char character = (char)overflowUnicode;
                        
                        // append the new character to newText
                        newText += character;
                    }
                    else
                    {
                        char character = (char)shiftUnicode;
                        // append the new character to newText
                        newText += character;
                    }
    
                }
                // Print the value of newText to the Console
                Console.WriteLine(newText);
                Console.ReadLine();
            }
        }
    }
