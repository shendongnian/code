    string SeparateToWords(string pascalSentence)
    {
        if(string.IsNullOrEmpty(pascalSentence))
        {
            return pascalSencentce;
        }
        var sb = new StringBuilder();
        // note I'm starting from 1 not from 0 here
        for(var i = 1; i < pascalSentence.Length; i++)
        {
            if(char.IsUpper(pascalSentence[i]))
            {
                sb.Append(" ").Append(pascalSentence[i].ToString().ToLower());
            }
            else
            {
                sb.Append(pascalSentence[i]);
            }
        }
        sb.Insert(0, pascalSentence[0]);
        return sb.ToString();
    }
