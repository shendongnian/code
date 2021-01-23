    string input_text = "Some Înput text here,\nÎs another lÎne of thÎs text.";
    string line_pattern = "\n";
    // split the string into string arrays
    string[] input_texts = input_text.Split(new string[] { line_pattern }, StringSplitOptions.RemoveEmptyEntries);
    string invalid_character = "Î";
    if (input_texts != null && input_texts.Length > 0)
    {
        if (input_texts.Length == 1)
        {
            Console.WriteLine("Is a single line file");
        }
        // loop every line
        foreach (string oneline in input_texts)
        {
            Regex regex = new Regex(invalid_character);
            MatchCollection mc = regex.Matches(oneline);
            Console.WriteLine("How many matches: {0}", mc.Count);
            foreach (Match match in mc)
            {
                Console.WriteLine("Index: {0}", match.Index);
            }
        }
    }
