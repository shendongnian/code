    string input = "First sentence. Second sentence! Third sentence? Yes.";
    string[] sentences = Regex.Split(input, @"(?<=[\.!\?])\s+");
    List<string> lines = new List<string>();
    string line = "";
    foreach (string sentence in sentences)
    {
        string[] words = sentence.Split(' ');
        foreach (string word in words)
        {
            if (line.Length + word.Length < 14)
                line += word + " ";
            else
            {
                lines.Add(line);
                line = word+ " ";
            }
        }
        lines.Add(line);
        line = "";
    }
    //Output: 
    //First
    //sentence
    //Second
    //sentence!
    //Third
    //sentence?
    //Yes
