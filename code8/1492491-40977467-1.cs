    static void Main(string[] args)
    {
        string line = string.Empty;
        using (var api = new KeystrokeAPI())
        {
            api.CreateKeyboardHook((character) => {
                if (character.KeyCode.ToString() == "Space" || character.KeyCode.ToString() == "Return")
                {
                    if(BannedWordsCheck(line))
                    {
                        Console.WriteLine("Banned Word Typed: " + line);
                    }
                    line = string.Empty;
                }
                else
                {
                    line += character.KeyCode.ToString();
                }
            });
            Application.Run();
        }
    }
    static bool BannedWordsCheck(string word)
    {
        if(word.ToLower().Contains("terror"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
