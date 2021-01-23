        class Program
    {
        static string HiddenWord = "";
        static char[] dashes;
        static void Main(string[] args)
        {
            int count = 0;
            HiddenWord = "csharp";
            dashes = new char[HiddenWord.Length];
 
            recursiveSetDashes(0);
            recursiveWriteDashes(0);
            Console.WriteLine();
            askUserToGuess(count);
            Console.ReadLine();
        }
        private static void recursiveWriteDashes(int v)
        {
            Console.Write(dashes[v] + "  ");
            v++; if (v < dashes.Length) recursiveWriteDashes(v);
        }
        private static void recursiveSetDashes(int i)
        {
            dashes[i] = '_';
            i++; if (i < dashes.Length) recursiveSetDashes(i);            
        }
        private static void askUserToGuess(int count)
        {
            Console.WriteLine("Enter a letter");
            char letter = char.Parse(Console.ReadLine());
            recursiveReplaceDashes(0,letter,ref count);
            if (count < dashes.Length) askUserToGuess(count);
        }
        private static void recursiveReplaceDashes(int v, char letter, ref int count)
        {
            if ((HiddenWord[v] == letter) && (dashes[v] != letter))
            {
                count++; dashes[v] = letter;  
                recursiveWriteDashes(0);
            }
            v++; if (v < dashes.Length) recursiveReplaceDashes(v, letter, ref count);
        }
    }
