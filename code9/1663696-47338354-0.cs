     using System.Linq;
        string line = "Dog ate my apple,so i am sad wow.";
        char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
        string[] parts = line.Split(skyrikliai, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in parts)
        {
            char[] letters = word.ToCharArray();
            var DisintctLetters = letters.Distinct().ToArray();
            if (letters.Length != DisintctLetters.Length)
            {
                line = line.Replace(word, "");
            }
        }
       Console.WriteLine(line);
