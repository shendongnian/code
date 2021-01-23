    static string splitAndFindElement(string input, char splitter, int index, string resultOnFail)
    {
        var succesful = false;
        string[] words = null;
        if (input != null)
        {
            words = input.Split(splitter);
            succesful = words.Length > index;
        }
        return succesful ? words[index] : resultOnFail;
    }
