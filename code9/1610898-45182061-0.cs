    public string FindMacroType(string sentence)
    {
        Regex begin = new Regex(@"(\{)(BEGIN\:)[0-9][0-9][0-9](\})",RegexOptions.IgnoreCase);
        sentence = begin.Replace(sentence,"");
        Regex end = new Regex(@"(\{)(END\:)[0-9][0-9][0-9](\})", RegexOptions.IgnoreCase);
        sentence = end.Replace(sentence, "");
        return sentence;
    }
