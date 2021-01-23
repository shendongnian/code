    String text = "Johnny, you use.\nEye eager sun.";
    // Splits the text into individual words
    String[] words = text.ToLower().Split(new String[] {" ", ",", ".", "\n"}, StringSplitOptions.RemoveEmptyEntries);
    String lastLetter = text.ToLower()[0].ToString();
    String newText = text;
    // Checks to see if the last letter if the previous word matches with the first letter of the next word
    foreach (String word in words)
    {
        if (word.StartsWith(lastLetter))
        {
            lastLetter = word[word.Length - 1].ToString();
        }
        else
        {
            newText = text.Split(new String[] { word }, StringSplitOptions.RemoveEmptyEntries)[0]; // Split the original text at the location where the inconsistency happens and take the first text fragment.
            break;
        }
    }
    Console.WriteLine(text);
    Console.WriteLine(newText);
