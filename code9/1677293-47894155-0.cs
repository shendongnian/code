    using System;
    namespace MyApp {
    class KeyBoardInputTest {
    static void Main(string [] args) {    // This line has been changed
        Console.Write("Enter a character >\t");
        char ch = Convert.ToChar(args[0])   // This line has been changed
        Console.WriteLine("");
        if(Char.IsLetter(ch)) {
            if(Char.IsUpper(ch))
                Console.WriteLine("You have entered an upper case character");
            else
                Console.WriteLine("You have entered a lower case character");
        }
        else if(Char.IsNumber(ch))
            Console.WriteLine("You have entered a numeric character");
        else
            Console.WriteLine("You have entered a non alpha-numeric character");
        Console.Read();
    }
    }
    } 
